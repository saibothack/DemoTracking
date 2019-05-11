using DemoTracking.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoTracking.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public string Name { get; set; }

        [ForeignKey("Company")]
        public string CompanyID { get; set; }
        public virtual Company Company { get; set; }

        public UserStatus Status { get; set; }
    }

    public enum UserStatus
    {
        Activo,
        Inactivo
    }
}
