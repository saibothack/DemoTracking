using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoTracking.Models;
using DemoTracking.Models.Vehicles;

namespace DemoTracking.Pages.vehicles.checks
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
            return Page();
        }

        [BindProperty]
        public Ckeck Ckeck { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ckeck.Add(Ckeck);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}