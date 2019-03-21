using DrSys.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrSys.Data
{
    public class DrSysContext: DbContext
    {
        public DrSysContext(DbContextOptions<DrSysContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MedicalSchool> MedicalSchools { get; set; }
        public DbSet<PatientRating> PatientRatings { get; set; }
        public DbSet<Specialty> Specialties { get; set; }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            try
            {
                //return .ToList();
                return null;
            }
            catch
            {
                throw;
            }
        }
    }
}
