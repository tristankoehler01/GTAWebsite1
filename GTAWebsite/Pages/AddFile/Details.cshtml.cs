using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GTAWebsite.Data;
using GTAWebsite.Models;

namespace GTAWebsite.Pages.AddFile
{
    public class DetailsModel : PageModel
    {
        private readonly GTAWebsite.Data.GTAWebsiteContext _context;

        public DetailsModel(GTAWebsite.Data.GTAWebsiteContext context)
        {
            _context = context;
        }

      public FileModel FileModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FileModel == null)
            {
                return NotFound();
            }

            var filemodel = await _context.FileModel.FirstOrDefaultAsync(m => m.Id == id);
            if (filemodel == null)
            {
                return NotFound();
            }
            else 
            {
                FileModel = filemodel;
            }
            return Page();
        }
    }
}
