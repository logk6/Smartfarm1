using System.ComponentModel.DataAnnotations;

namespace Smartfarm1.Models
{
    public class FarmStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int CO2 { get; set; }
        public int SoilMoisture { get; set; }
        public int Light_0x5C { get; set; }
    }
}
