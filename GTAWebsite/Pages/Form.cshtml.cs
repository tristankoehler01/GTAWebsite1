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

namespace GTAWebsite.Pages
{

    [Authorize]
    public class FormModel : PageModel

    {
        private IConfiguration _configuration;
        private readonly ILogger<FormModel> _logger;
        public GTAWebsite.Data.GTAWebsiteContext _context;
        public List<FileModel> Files;


        [BindProperty]
        public FormApplication Form { get; set; } = default!;

        public FormModel(IConfiguration configuration, ILogger<FormModel> logger, GTAWebsite.Data.GTAWebsiteContext context)
        {
            _configuration = configuration;
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            this.Files = this.GetFiles();
        }

        public IActionResult OnPostUploadFile(IFormFile postedFile)
        {
            string fileName = Path.GetFileName(postedFile.FileName);
            string contentType = postedFile.ContentType;
            using (MemoryStream ms = new MemoryStream())
            {
                postedFile.CopyTo(ms);
                string constr = this._configuration.GetConnectionString("GTAWebsiteContext");
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "INSERT INTO Files VALUES (@Name, @ContentType, @Data)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Name", fileName);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        cmd.Parameters.AddWithValue("@Data", ms.ToArray());
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }

            if (!ModelState.IsValid || _context.FormApplication == null || Form == null)
            {
                return Page();
            }

            _context.FormApplication.Add(Form);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }

        public FileResult OnGetDownloadFile(int fileId)
        {
            byte[] bytes;
            string fileName, contentType;
            string constr = this._configuration.GetConnectionString("GTAWebsiteContext");
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Name, Data, ContentType FROM Files WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", fileId);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["Name"].ToString();
                    }
                    con.Close();
                }
            }

            return File(bytes, contentType, fileName);
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
