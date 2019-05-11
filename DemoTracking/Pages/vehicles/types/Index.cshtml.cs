using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;
using DemoTracking.Models.Vehicles;

namespace DemoTracking.Pages.vehicles.types
{
    public class IndexModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public IndexModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        public IList<Models.Vehicles.Type> Type { get;set; }

        public async Task OnGetAsync()
        {
            Type = await _context.Type.ToListAsync();
        }
    }
}
