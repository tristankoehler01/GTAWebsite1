using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        public bool GtaCertified { get; set; }
    }


}
