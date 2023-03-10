using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Application_Form.Pages
{
    public class FormApplicationModel : PageModel

    {
        [BindProperty]
        public string FirstName { get; set; } = "";


        [BindProperty]
        public string LastName { get; set; } = "";

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Phone { get; set; } = "";

        [BindProperty]
        public bool GtaCertified { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Please select a file.")]
        [Display(Name = "Attachment")]
        public IFormFile Attachment { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {

        }
    }
}
