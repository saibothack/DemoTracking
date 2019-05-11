using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoTracking.Models;
using Microsoft.AspNetCore.Identity;
using DemoTracking.Areas.Identity.Data;

namespace DemoTracking.Pages.companys
{
    public class CreateModel : PageModel
    {
        private readonly DemoTrackingContext _context;
        private readonly UserManager<User> _userManager;

        public CreateModel(DemoTrackingContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            var enumValues = Enum.GetValues(typeof(CompanyStatus)).Cast<CompanyStatus>().Select(e => new { Value = e.ToString(), Text = e.ToString() }).ToList();
            ViewData["CompanyStatus"] = new SelectList(enumValues, "Value", "Text", "");

            return Page();
        }

        [BindProperty]
        public Company Company { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentUser = await _userManager.GetUserAsync(User);

            Company.CreationDate = DateTime.Now;
            Company.OwnerId = currentUser.Id;

            _context.Company.Add(Company);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}