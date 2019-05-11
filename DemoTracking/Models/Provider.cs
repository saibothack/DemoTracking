using System.ComponentModel.DataAnnotations;

namespace DemoTracking.Models
{
    public class Provider : DefaultData
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
