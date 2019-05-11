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
    public class DetailsModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public DetailsModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        public Maintenance Maintenance { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Maintenance = await _context.Maintenance
                .Include(m => m.Provider)
                .Include(m => m.Vehicle).FirstOrDefaultAsync(m => m.id == id);

            if (Maintenance == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
