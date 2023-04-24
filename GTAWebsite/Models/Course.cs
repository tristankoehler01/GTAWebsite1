using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
namespace GTAWebsite.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Course Name"), Required]
        public string courseName { get; set; }

        [Display(Name = "Course Description"), Required]
        public string courseDescription { get; set; }

        [Display(Name = "Position"), Required]
        public string positionName { get; set; }

        [Display(Name = "Qualification"), Required]
        public string qualificationName { get; set; }
    }
}
