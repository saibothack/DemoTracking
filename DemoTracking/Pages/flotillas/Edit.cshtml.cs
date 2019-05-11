using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;

namespace DemoTracking.Pages.flotillas
{
    public class EditModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public EditModel(DemoTracking.Models.DemoTrackingContext context)
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
           ViewData["CompanyID"] = new SelectList(_context.Company, "id", "id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Flotilla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlotillaExists(Flotilla.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FlotillaExists(string id)
        {
            return _context.Flotilla.Any(e => e.id == id);
        }
    }
}
