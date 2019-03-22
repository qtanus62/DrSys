using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
