using System.ComponentModel.DataAnnotations;

namespace Smartfarm1.Models
{
    public class FarmStatusNow
    {
        [Key]
        public DateTime DateTime { get; set; }
        [Required]
        public int SFID { get; set; }
        public int CO2 { get; set; }
        public int SoilMoisture { get; set; }
        public int Light_0x5C { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
    }
}
