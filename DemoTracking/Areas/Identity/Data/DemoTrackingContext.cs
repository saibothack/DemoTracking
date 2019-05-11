using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoTracking.Areas.Identity.Data;
using DemoTracking.Models.Vehicles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;

namespace DemoTracking.Models
{
    public class DemoTrackingContext : IdentityDbContext<User>
    {
        public DemoTrackingContext(DbContextOptions<DemoTrackingContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<DemoTracking.Models.Provider> Provider { get; set; }

        public DbSet<DemoTracking.Models.Vehicles.Type> Type { get; set; }

        public DbSet<DemoTracking.Models.Vehicles.Ckeck> Ckeck { get; set; }

        public DbSet<DemoTracking.Models.Company> Company { get; set; }

        public DbSet<DemoTracking.Models.Flotilla> Flotilla { get; set; }

        public DbSet<DemoTracking.Models.Maintenance> Maintenance { get; set; }

        public DbSet<DemoTracking.Models.Vehicles.Vehicle> Vehicle { get; set; }

        public DbSet<DemoTracking.Areas.Identity.Data.Role> Role { get; set; }

        public DbSet<DemoTracking.Areas.Identity.Data.User> User { get; set; }

    }
}
