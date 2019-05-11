using System.ComponentModel.DataAnnotations;

namespace DemoTracking.Models.Vehicles
{
    public class Ckeck : DefaultData
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}
