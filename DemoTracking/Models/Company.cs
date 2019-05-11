using System.ComponentModel.DataAnnotations;

namespace DemoTracking.Models
{
    public class Company : DefaultData
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre de la empresa")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [Required]
        [Display(Name = "Estatus")]
        public CompanyStatus Status { get; set; }
    }

    public enum CompanyStatus
    {
        Activo,
        Inactivo
    }
}
