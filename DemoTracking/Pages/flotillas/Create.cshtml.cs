using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoTracking.Models;

namespace DemoTracking.Pages.flotillas
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
        ViewData["CompanyID"] = new SelectList(_context.Company, "id", "id");
            return Page();
        }

        [BindProperty]
        public Flotilla Flotilla { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Flotilla.Add(Flotilla);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}