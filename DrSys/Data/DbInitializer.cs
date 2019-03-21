using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrSys.Models;
using Microsoft.EntityFrameworkCore;

namespace DrSys.Data
{
    public class DbInitializer
    {
        public static void Initialize(DrSysContext context)
        {
            // Look for any doctors.
            if (context.Doctors.Any())
            {
                return;   // DB has been seeded
            }

            var doctor = new Doctor[]
            {
                new Doctor { Id = 0,   Name = "John Doe", Gender = "M", MedicalSchoolId = 0, LanguageId = 0 }
            };

            foreach (Doctor d in doctor)
            {
                context.Doctors.Add(d);
            }

            var drSpec = new DoctorSpecialty[]
            {
                new DoctorSpecialty { DoctorId = 0,   SpecialtyId = 0 }
            };

            foreach (DoctorSpecialty ds in drSpec)
            {
                context.DoctorSpecialties.Add(ds);
            }

            var lang = new Language[]
            {
                new Language { Id = 0,   LangName = "English" }
            };

            foreach (Language l in lang)
            {
                context.Languages.Add(l);
            }

            var medSch = new MedicalSchool[]
            {
                new MedicalSchool { Id = 0,   MedSchName = "UGA" }
            };

            foreach (MedicalSchool ms in medSch)
            {
                context.MedicalSchools.Add(ms);
            }

            var patRat = new PatientRating[]
            {
                new PatientRating { DoctorId = 0,   Comments = "Excellent!", Rating = 5 }
            };

            foreach (PatientRating pr in patRat)
            {
                context.PatientRatings.Add(pr);
            }

            var spec = new Specialty[]
            {
                new Specialty { Id = 0,   SpecName = "Family Medicine" }
            };

            foreach (Specialty s in spec)
            {
                context.Specialties.Add(s);
            }

            context.SaveChanges();
            
        }
    }
}
