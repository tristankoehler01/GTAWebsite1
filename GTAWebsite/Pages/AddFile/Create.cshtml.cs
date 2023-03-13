using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GTAWebsite.Data;
using GTAWebsite.Models;

namespace GTAWebsite.Pages.AddFile
{
    public class CreateModel : PageModel
    {
        private readonly GTAWebsite.Data.GTAWebsiteContext _context;

        public CreateModel(GTAWebsite.Data.GTAWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FileModel FileModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FileModel == null || FileModel == null)
            {
                return Page();
            }

            _context.FileModel.Add(FileModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
