using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GTAWebsite.Data;
using GTAWebsite.Models;

namespace GTAWebsite.Pages.AddFile
{
    public class EditModel : PageModel
    {
        private readonly GTAWebsite.Data.GTAWebsiteContext _context;

        public EditModel(GTAWebsite.Data.GTAWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileModel FileModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FileModel == null)
            {
                return NotFound();
            }

            var filemodel =  await _context.FileModel.FirstOrDefaultAsync(m => m.Id == id);
            if (filemodel == null)
            {
                return NotFound();
            }
            FileModel = filemodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FileModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileModelExists(FileModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FileModelExists(int id)
        {
          return (_context.FileModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
