using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoTracking.Models;
using DemoTracking.Models.Vehicles;

namespace DemoTracking.Pages.vehicles
{
    public class CreateModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public CreateModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CkeckID"] = new SelectList(_context.Ckeck, "id", "id");
        ViewData["CompanyID"] = new SelectList(_context.Company, "id", "id");
        ViewData["FlotillaID"] = new SelectList(_context.Flotilla, "id", "id");
        ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vehicle.Add(Vehicle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}