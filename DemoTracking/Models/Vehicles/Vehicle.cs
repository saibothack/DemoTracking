using DemoTracking.Areas.Identity.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoTracking.Models.Vehicles
{
    public class Vehicle
    {
        [Key]
        public string id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Placas")]
        public string Plates { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Aceite (km)")]
        public double Oil { get; set; }

        [Required]
        [Display(Name = "Frenos (km)")]
        public double Brakes { get; set; }

        [Required]
        [Display(Name = "Kit (km)")]
        public double Kit { get; set; }

        [Required]
        [Display(Name = "Amortiguadores (km)")]
        public string ShockAbsorber { get; set; }

        [Required]
        [Display(Name = "Neumáticos (km)")]
        public double Tires { get; set; }

        [Required]
        [Display(Name = "Mantenimiento (km)")]
        public double Maintenance { get; set; }

        [ForeignKey("Ckeck")]
        [Display(Name = "Verificación")]
        public string CkeckID { get; set; }
        public virtual Ckeck Ckeck { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Recordatorio Tenencia")]
        public DateTime Tenure { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Recordatorio Seguro")]
        public DateTime Safe { get; set; }

        [ForeignKey("User")]
        [Display(Name = "Usuario")]
        public string UserID { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Flotilla")]
        [Display(Name = "Flotilla")]
        public string FlotillaID { get; set; }
        public virtual Flotilla Flotilla { get; set; }

        [ForeignKey("Company")]
        [Display(Name = "Empresa")]
        public string CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
