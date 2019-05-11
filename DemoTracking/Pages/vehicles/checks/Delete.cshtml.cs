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
    public class DeleteModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public DeleteModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ckeck Ckeck { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ckeck = await _context.Ckeck.FirstOrDefaultAsync(m => m.id == id);

            if (Ckeck == null)
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

            Ckeck = await _context.Ckeck.FindAsync(id);

            if (Ckeck != null)
            {
                _context.Ckeck.Remove(Ckeck);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
