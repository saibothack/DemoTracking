using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;

namespace DemoTracking.Pages.flotillas
{
    public class DeleteModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public DeleteModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Flotilla Flotilla { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flotilla = await _context.Flotilla
                .Include(f => f.Company).FirstOrDefaultAsync(m => m.id == id);

            if (Flotilla == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flotilla = await _context.Flotilla.FindAsync(id);

            if (Flotilla != null)
            {
                _context.Flotilla.Remove(Flotilla);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
