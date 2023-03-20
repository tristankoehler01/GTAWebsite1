using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace GTAWebsite.Models
{
    [Authorize(Roles = "Administrator")]
    public class User : Controller
    {
        public IActionResult Index() =>
         Content("Administrator");
    }
}
