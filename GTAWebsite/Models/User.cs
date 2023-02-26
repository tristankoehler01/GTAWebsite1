﻿using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
namespace GTAWebsite.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
