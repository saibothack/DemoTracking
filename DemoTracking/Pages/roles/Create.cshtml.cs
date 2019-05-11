using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoTracking.Areas.Identity.Data;
using DemoTracking.Models;
using Microsoft.AspNetCore.Identity;

namespace DemoTracking.Pages_roles
{
    public class CreateModel : PageModel
    {
        private readonly RoleManager<Role> _roleManager;

        public CreateModel(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Role Role { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _roleManager.CreateAsync(Role);

            return RedirectToPage("./Index");
        }
    }
}