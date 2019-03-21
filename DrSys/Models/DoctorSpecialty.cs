using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrSys.Models
{
    public class DoctorSpecialty
    {
        [ForeignKey("Doctor")]
        [Key]
        public int DoctorId { get; set; }

        [ForeignKey("Specialty")]
        public int SpecialtyId { get; set; }
    }
}
