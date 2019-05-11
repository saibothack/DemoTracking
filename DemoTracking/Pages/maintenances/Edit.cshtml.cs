using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;

namespace DemoTracking.Pages_maintenances
{
    public class EditModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public EditModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["ProviderID"] = new SelectList(_context.Provider, "id", "id");
           ViewData["VehicleID"] = new SelectList(_context.Vehicle, "id", "id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Maintenance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceExists(Maintenance.id))
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

        private bool MaintenanceExists(string id)
        {
            return _context.Maintenance.Any(e => e.id == id);
        }
    }
}
