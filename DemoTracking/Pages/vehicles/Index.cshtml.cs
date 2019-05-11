using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;
using DemoTracking.Models.Vehicles;

namespace DemoTracking.Pages.vehicles
{
    public class IndexModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public IndexModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicle { get;set; }

        public async Task OnGetAsync()
        {
            Vehicle = await _context.Vehicle
                .Include(v => v.Ckeck)
                .Include(v => v.Company)
                .Include(v => v.Flotilla)
                .Include(v => v.User).ToListAsync();
        }
    }
}
