using System.ComponentModel.DataAnnotations;

namespace DemoTracking.Models.Vehicles
{
    public class Type : DefaultData
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Tipo de vehículo")]
        public string Name { get; set; }
    }
}