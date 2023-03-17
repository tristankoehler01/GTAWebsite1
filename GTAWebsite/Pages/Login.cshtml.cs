using GTAWebsite.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace GTAWebsite.Pages.Account
{
    public class LoginModel : PageModel
    {
        public GTAWebsite.Data.GTAWebsiteContext _context;

        [BindProperty]
        public Credential Credential { get; set; }

        public LoginModel(GTAWebsiteContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
        }
    }

    public class Credential
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]  
        public string Password { get; set; }
    }
}
