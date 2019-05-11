using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Areas.Identity.Data;
using DemoTracking.Models;
using Microsoft.AspNetCore.Identity;

namespace DemoTracking.Pages_roles
{
    public class DetailsModel : PageModel
    {
        private readonly RoleManager<Role> _roleManager;

        public DetailsModel(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public Role Role { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Role = await _roleManager.FindByIdAsync(id);

            if (Role == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
