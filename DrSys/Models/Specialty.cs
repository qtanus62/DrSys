using System.ComponentModel.DataAnnotations;

namespace DrSys.Models
{
    public class Specialty
    {
        [Key]
        public int Id { get; set; }
        public string SpecName { get; set; }
    }
}
