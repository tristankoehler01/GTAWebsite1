using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GTAWebsite.Data;
using GTAWebsite.Models;

namespace GTAWebsite.Pages.Applications
{
    public class ApplicationIndexModel : PageModel
    {
        private readonly GTAWebsite.Data.GTAWebsiteContext _context;

        public ApplicationIndexModel(GTAWebsite.Data.GTAWebsiteContext context)
        {
            _context = context;
        }

        public IList<FormApplication> FormApplication { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Forms != null)
            {
                FormApplication = await _context.Forms.ToListAsync();
            }
        }
    }
}
