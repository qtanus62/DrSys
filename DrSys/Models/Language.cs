using System.ComponentModel.DataAnnotations;

namespace DrSys.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string LangName { get; set; }
    }
}
