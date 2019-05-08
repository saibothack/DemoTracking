using System;
using DemoTracking.Areas.Identity.Data;
using DemoTracking.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DemoTracking.Areas.Identity.IdentityHostingStartup))]
namespace DemoTracking.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DemoTrackingContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DemoTrackingContextConnection")));

                services.AddDefaultIdentity<User>()
                    .AddEntityFrameworkStores<DemoTrackingContext>();
            });
        }
    }
}