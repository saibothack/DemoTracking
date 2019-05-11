using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using PagedList;
using DemoTracking.utils;

namespace DemoTracking.Pages_roles
{
    public class IndexModel : PageModel
    {
        private readonly RoleManager<Role> _roleManager;

        public IndexModel(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public PaginatedList<Role> Role { get;set; }
        public int RoleCount { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string search, int? pageIndex)
        {
            ViewData["NameSortParm"] = !String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (search != null)
            {
                pageIndex = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewData["CurrentFilter"] = search;

            var slRole = from x in (_roleManager.Roles)
                         select x;

            if (!String.IsNullOrEmpty(search))
            {
                slRole = slRole.Where(x => x.Name.Contains(search));
            }

            switch (sortOrder) {
                case "name_desc":
                    slRole = slRole.OrderByDescending(x => x.Name);
                    break;
                default:
                    slRole = slRole.OrderBy(x => x.Name);
                    break;
            }

            RoleCount = ((slRole.Count() / 10) + 1);

            int pageSize = 10;
            Role = await PaginatedList<Role>.CreateAsync(
                slRole.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
