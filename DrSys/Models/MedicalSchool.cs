using System.ComponentModel.DataAnnotations;

namespace DrSys.Models
{
    public class MedicalSchool
    {
        [Key]
        public int Id { get; set; }
        public string MedSchName { get; set; }

    }
}
