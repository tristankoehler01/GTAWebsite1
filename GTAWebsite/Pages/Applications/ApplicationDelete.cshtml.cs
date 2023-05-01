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
    public class ApplicationDeleteModel : PageModel
    {
        private readonly GTAWebsite.Data.GTAWebsiteContext _context;

        public ApplicationDeleteModel(GTAWebsite.Data.GTAWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public FormApplication FormApplication { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Forms == null)
            {
                return NotFound();
            }

            var formapplication = await _context.Forms.FirstOrDefaultAsync(m => m.Id == id);

            if (formapplication == null)
            {
                return NotFound();
            }
            else 
            {
                FormApplication = formapplication;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Forms == null)
            {
                return NotFound();
            }
            var formapplication = await _context.Forms.FindAsync(id);

            if (formapplication != null)
            {
                FormApplication = formapplication;
                _context.Forms.Remove(FormApplication);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
