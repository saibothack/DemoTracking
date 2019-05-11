using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoTracking.Models
{
    public class Flotilla : DefaultData
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [ForeignKey("Company")]
        [Display(Name = "Empresa")]
        public string CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
