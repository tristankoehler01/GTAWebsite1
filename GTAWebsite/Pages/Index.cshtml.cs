using GTAWebsite.Data;
using GTAWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GTAWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private IConfiguration _configuration;
        private readonly ILogger<IndexModel> _logger;
        public GTAWebsite.Data.GTAWebsiteContext _context;

        public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger, GTAWebsite.Data.GTAWebsiteContext context)
        {
            _configuration = configuration;
            _logger = logger;
            _context = context;
        }

        public static List<Course> Course { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Course != null)
            {
                Course = await _context.Course.ToListAsync();
            }
        }

    }
}