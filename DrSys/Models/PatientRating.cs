using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrSys.Models
{
    public class PatientRating
    {
        [ForeignKey("Doctor")]
        [Key]
        public int DoctorId { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
    }
}
