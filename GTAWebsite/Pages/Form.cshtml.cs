using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using GTAWebsite.Models;
using System.IO;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using GTAWebsite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GTAWebsite.Pages
{

    [Authorize(Policy = "RequireStudentRole")]
    public class FormModel : PageModel

    {
        private GTAWebsiteContext _context;
        private ILogger<FormModel> _logger;
        private IConfiguration _configuration;
        public List<FileModel> files;


        public FormModel(GTAWebsiteContext context, ILogger<FormModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        [BindProperty]
        public FormApplication form { get; set; } = default!;

        public void OnGet()
        {
            this.files = this.GetFiles();
        }

        public IActionResult OnPostUploadFile(List<IFormFile> Attachment)
        {

            foreach (var file in Attachment)
            {
                string fileName = Path.GetFileName(file.FileName);
                string contentType = file.ContentType;
                using (MemoryStream ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    string constr = this._configuration.GetConnectionString("GTAWebsiteContext");
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = "INSERT INTO Files VALUES (@FormID, @Name, @ContentType, @Data)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@FormID", form.Id);
                            cmd.Parameters.AddWithValue("@Name", fileName);
                            cmd.Parameters.AddWithValue("@ContentType", contentType);
                            cmd.Parameters.AddWithValue("@Data", ms.ToArray());
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }

            if (!ModelState.IsValid || _context.Forms == null || form == null)
            {
                return Page();
            }

            _context.Forms.Add(form);
            _context.SaveChanges();

            form = new FormApplication();
            TempData["Message"] = "Application submitted successfully.";

            return RedirectToPage("Index");
        }


        private List<FileModel> GetFiles()
        {
            List<FileModel> files = new List<FileModel>();
            string constr = this._configuration.GetConnectionString("GTAWebsiteContext");
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM Files"))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            files.Add(new FileModel
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                Name = sdr["Name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return files;
        }

    }
}
