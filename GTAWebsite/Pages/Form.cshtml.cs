using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using GTAWebsite.Data;
using GTAWebsite.Models;

namespace Form
{


    public class FormModel : PageModel

    {
        private IConfiguration _configuration;
        private readonly ILogger<FormModel> _logger;
        public GTAWebsite.Data.GTAWebsiteContext _context;


        [BindProperty]
        public FormApplication form { get; set; } = default!;

        [BindProperty]
        public SingleFileUploadDb fileUpload { get; set; }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await fileUpload.file.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var fileM = new FileModel()
                    {
                        Content = memoryStream.ToArray()
                    };

                    _context.FormApplication.Add(form);
                    _context.FileModel.Add(fileM);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            return RedirectToPage("Index");
        }


    }

    public class SingleFileUploadDb
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "File")]
        public IFormFile file;
    }
}
