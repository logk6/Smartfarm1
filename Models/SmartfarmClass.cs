using System.ComponentModel.DataAnnotations;

namespace Smartfarm1.Models
{
    public class SmartfarmClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string IPAddress { get; set; }
    }
}
