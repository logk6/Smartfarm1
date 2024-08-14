using System.ComponentModel.DataAnnotations;

namespace Smartfarm1.Models
{
    public class FarmStatus
    {
        //
        //public int Id { get; set; }
        //
        [Key]
        public DateTime DateTime { get; set; } = DateTime.Now;
        [Required]
        public int CO2 { get; set; }
        public int SoilMoisture { get; set; }
        public int Light_0x5C { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }

    }
}
