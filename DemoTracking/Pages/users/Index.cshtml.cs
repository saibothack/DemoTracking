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
using DemoTracking.utils;

namespace DemoTracking.Pages_users
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        public string CompanySort { get; } = "company_desc";
        public string NameSort { get; } = "name_desc";
        public string UserNameSort { get; } = "user_name_desc";
        public string EmailSort { get; } = "email_desc";
        public string PhoneNumberSort { get; } = "phone_desc";
        public string StatusNumberSort { get; } = "status_desc";

        public IndexModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public PaginatedList<User> User { get; set; }
        public int itemCount { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string search, int? pageIndex)
        {
            if (search != null)
            {
                pageIndex = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewData["CurrentFilter"] = search;

            var slUsers = from x in (_userManager.Users)
                            select x;

            if (!String.IsNullOrEmpty(search))
            {
                slUsers = slUsers.Where(x => x.Name.Contains(search)
                                        || x.UserName.Contains(search)
                                        || x.Email.Contains(search)
                                        || x.PhoneNumber.Contains(search)
                                        || x.Company.Name.Contains(search));
            }

            switch (sortOrder)
            {
                case "company_desc":
                    slUsers = slUsers.OrderByDescending(x => x.Company.Name);
                    break;
                case "name_desc":
                    slUsers = slUsers.OrderByDescending(x => x.Name);
                    break;
                case "user_name_desc":
                    slUsers = slUsers.OrderByDescending(x => x.UserName);
                    break;
                case "email_desc":
                    slUsers = slUsers.OrderByDescending(x => x.Email);
                    break;
                case "phone_desc":
                    slUsers = slUsers.OrderByDescending(x => x.PhoneNumber);
                    break;
                default:
                    slUsers = slUsers.OrderBy(x => x.Name);
                    break;
            }

            itemCount = ((slUsers.Count() / 10) + 1);

            int pageSize = 10;
            User = await PaginatedList<User>.CreateAsync(
                slUsers.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
