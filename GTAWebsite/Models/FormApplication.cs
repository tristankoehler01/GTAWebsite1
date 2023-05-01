using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GTAWebsite.Models
{
    public class FormApplication
    {
        public int Id { get; set; }

        [BindProperty]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = "";

        
        [BindProperty]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = "";

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Phone { get; set; } = "";

        [BindProperty]
        [Required]
        [Display(Name = "Student ID")]
        public string StudentID { get; set; } = "";

        [BindProperty]
        [Required]
        [Display(Name = "Grade")]
        public string Grade { get; set; } = "";

        [BindProperty]
        [Display(Name = "GTA Certified?")]
        public bool GtaCertified { get; set; }
    }
}
