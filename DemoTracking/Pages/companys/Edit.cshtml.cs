using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;
using Microsoft.AspNetCore.Identity;
using DemoTracking.Areas.Identity.Data;

namespace DemoTracking.Pages.companys
{
    public class EditModel : PageModel
    {
        private readonly DemoTrackingContext _context;
        private readonly UserManager<User> _userManager;

        public EditModel(DemoTrackingContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Company.FirstOrDefaultAsync(m => m.id == id);

            if (Company == null)
            {
                return NotFound();
            }

            var enumValues = Enum.GetValues(typeof(CompanyStatus)).Cast<CompanyStatus>().Select(e => new { Value = e.ToString(), Text = e.ToString() }).ToList();
            ViewData["CompanyStatus"] = new SelectList(enumValues, "Value", "Text", "");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentUser = await _userManager.GetUserAsync(User);

            Company.EditionDate = DateTime.Now;
            Company.EditionOwnerId = currentUser.Id;

            _context.Attach(Company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(Company.id))
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

        private bool CompanyExists(string id)
        {
            return _context.Company.Any(e => e.id == id);
        }
    }
}
