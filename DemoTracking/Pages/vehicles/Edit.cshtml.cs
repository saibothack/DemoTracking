using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;
using DemoTracking.Models.Vehicles;

namespace DemoTracking.Pages.vehicles
{
    public class EditModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public EditModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehicle = await _context.Vehicle
                .Include(v => v.Ckeck)
                .Include(v => v.Company)
                .Include(v => v.Flotilla)
                .Include(v => v.User).FirstOrDefaultAsync(m => m.id == id);

            if (Vehicle == null)
            {
                return NotFound();
            }
           ViewData["CkeckID"] = new SelectList(_context.Ckeck, "id", "id");
           ViewData["CompanyID"] = new SelectList(_context.Company, "id", "id");
           ViewData["FlotillaID"] = new SelectList(_context.Flotilla, "id", "id");
           ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(Vehicle.id))
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

        private bool VehicleExists(string id)
        {
            return _context.Vehicle.Any(e => e.id == id);
        }
    }
}
