using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;

namespace DemoTracking.Pages_maintenances
{
    public class IndexModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public IndexModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        public IList<Maintenance> Maintenance { get;set; }

        public async Task OnGetAsync()
        {
            Maintenance = await _context.Maintenance
                .Include(m => m.Provider)
                .Include(m => m.Vehicle).ToListAsync();
        }
    }
}
