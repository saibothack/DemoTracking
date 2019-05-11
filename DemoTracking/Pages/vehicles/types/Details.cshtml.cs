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
    public class DetailsModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public DetailsModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        public Models.Vehicles.Type Type { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Type = await _context.Type.FirstOrDefaultAsync(m => m.id == id);

            if (Type == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
