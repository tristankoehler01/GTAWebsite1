using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GTAWebsite.Data;
using GTAWebsite.Models;
using Microsoft.AspNetCore.Authorization;

namespace GTAWebsite.Pages.AddCourse
{
    [Authorize(Policy ="Administrator")]
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
        public Course Course { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          if (!ModelState.IsValid || _context.Course == null || Course == null)
            {
                return Page();
            }

            _context.Course.Add(Course);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
