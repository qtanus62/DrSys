using DrSys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DrSys.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        [ForeignKey("MedicalSchool")]
        public int MedicalSchoolId { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
    }

}
