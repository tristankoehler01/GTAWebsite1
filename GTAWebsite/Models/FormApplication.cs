using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GTAWebsite.Models
{
    public class FormApplication
    {
        public int Id { get; set; }

        [BindProperty]
        public string FirstName { get; set; } = "";


        [BindProperty]
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
        public bool GtaCertified { get; set; }

         
    }
}
