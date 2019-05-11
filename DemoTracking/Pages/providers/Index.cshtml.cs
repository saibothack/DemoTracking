using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoTracking.Models;

namespace DemoTracking.Pages.providers
{
    public class IndexModel : PageModel
    {
        private readonly DemoTracking.Models.DemoTrackingContext _context;

        public IndexModel(DemoTracking.Models.DemoTrackingContext context)
        {
            _context = context;
        }

        public IList<Provider> Provider { get;set; }

        public async Task OnGetAsync()
        {
            Provider = await _context.Provider.ToListAsync();
        }
    }
}
