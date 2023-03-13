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
    public class IndexModel : PageModel
    {
        private readonly GTAWebsite.Data.GTAWebsiteContext _context;

        public IndexModel(GTAWebsite.Data.GTAWebsiteContext context)
        {
            _context = context;
        }

        public IList<FileModel> FileModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FileModel != null)
            {
                FileModel = await _context.FileModel.ToListAsync();
            }
        }
    }
}
