using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
