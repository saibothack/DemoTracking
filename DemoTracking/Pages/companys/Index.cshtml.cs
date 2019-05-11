using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;
using DemoTracking.utils;

namespace DemoTracking.Pages.companys
{
    public class IndexModel : PageModel
    {
        private readonly DemoTrackingContext _context;

        public string NameSort { get; } = "name_desc";
        public string RFCSort { get; } = "rfc_desc";
        public string StatusSort { get; } = "status_desc";

        public IndexModel(DemoTrackingContext context)
        {
            _context = context;
        }

        public PaginatedList<Company> Company { get;set; }
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

            var slCompany = from x in (_context.Company)
                         select x;

            if (!String.IsNullOrEmpty(search))
            {
                slCompany = slCompany.Where(x => x.Name.Contains(search)
                        || x.RFC.Contains(search));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    slCompany = slCompany.OrderByDescending(x => x.Name);
                    break;
                case "rfc_desc":
                    slCompany = slCompany.OrderByDescending(x => x.RFC);
                    break;
                case "status_desc":
                    slCompany = slCompany.OrderByDescending(x => x.Status);
                    break;
                default:
                    slCompany = slCompany.OrderBy(x => x.Name);
                    break;
            }

            itemCount = ((slCompany.Count() / 10) + 1);

            int pageSize = 10;
            Company = await PaginatedList<Company>.CreateAsync(
                slCompany.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
