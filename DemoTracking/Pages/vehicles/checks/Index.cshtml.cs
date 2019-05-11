using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;
using DemoTracking.Models.Vehicles;

namespace DemoTracking.Pages.vehicles.checks
{
    public class IndexModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public IndexModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        public IList<Ckeck> Ckeck { get;set; }

        public async Task OnGetAsync()
        {
            Ckeck = await _context.Ckeck.ToListAsync();
        }
    }
}
