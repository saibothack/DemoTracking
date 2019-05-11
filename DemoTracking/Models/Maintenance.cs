using DemoTracking.Models.Vehicles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoTracking.Models
{
    public class Maintenance : DefaultData
    {
        [ForeignKey("Provider")]
        [Display(Name = "Proveedor")]
        public string ProviderID { get; set; }
        public virtual Provider Provider { get; set; }

        [ForeignKey("Vehicle")]
        [Display(Name = "Vehículo")]
        public string VehicleID { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Programada")]
        public string Scheduled { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Final")]
        public string DateEnd { get; set; }

        [Required]
        [Display(Name = "Estatus")]
        public MaintenanceStatus Status { get; set; }
    }

    public enum MaintenanceStatus
    {
        Programada,
        Cancelada,
        Completada
    }
}
