using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrSys.Data;

namespace DrSys.Models
{
    public class RetrieveData
    {
        private readonly DrSysContext db;

        //public List<DrSummary> GetDrSummary()
        //{
        //    List<DrSummary> listDrSum = new List<DrSummary>();
        //    listDrSum = (from d in db.Doctors
        //                 //join drSpec in db.DoctorSpecialties
        //                 //  on d.Id equals drSpec.DoctorId
        //                 //join spec in db.Specialties
        //                 //  on drSpec.SpecialtyId equals spec.Id
        //                 //join patRating in db.PatientRatings
        //                 //  on d.Id equals patRating.DoctorId
        //                 //group d by d.Name into dgroup
        //                 select new
        //                 {
        //                     d.Name,
        //                     d.Gender
        //                     //SpecialtyName = spec.SpecName,
        //                     //AverageRating = patRating.Rating

        //                     //patRating.Rating
        //                 }).ToList();
        //}
    }
}
