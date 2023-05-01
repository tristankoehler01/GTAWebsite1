using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GTAWebsite.Data;
using GTAWebsite.Models;
using System.Data.SqlClient;

namespace GTAWebsite.Pages.Applications
{
    public class ApplicationIndexModel : PageModel
    {
        private readonly GTAWebsite.Data.GTAWebsiteContext _context;
        private IConfiguration _configuration;
        public List<FileModel> Files { get; set; }

        public ApplicationIndexModel(GTAWebsite.Data.GTAWebsiteContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IList<FormApplication> FormApplication { get;set; } = default!;

        public async Task OnGetAsync()
        {
            this.Files = GetFiles();
            if (_context.Forms != null)
            {
                FormApplication = await _context.Forms.ToListAsync();
            }
        }

        [HttpGet("Applications/Download/{fileId}")]
        public FileResult OnGetDownload(int fileId)
        {
            byte[] fileBytes;
            string fileName, contentType;
            string constr = this._configuration.GetConnectionString("GTAWebsiteContext");
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT FormID, Name, Data, ContentType FROM Files WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", fileId);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        fileBytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["Name"].ToString();
                    }
                    con.Close();
                }
            }

            return File(fileBytes, contentType, fileName);
        }

        private List<FileModel> GetFiles()
        {
            List<FileModel> files = new List<FileModel>();
            string constr = this._configuration.GetConnectionString("GTAWebsiteContext");
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, FormID, Name FROM Files"))
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
                                FormID = Convert.ToInt32(sdr["FormID"]),
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
