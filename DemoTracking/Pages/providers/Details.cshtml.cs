using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;

namespace DemoTracking.Pages.providers
{
    public class DetailsModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public DetailsModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        public Provider Provider { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Provider = await _context.Provider.FirstOrDefaultAsync(m => m.id == id);

            if (Provider == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
