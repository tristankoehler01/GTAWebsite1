using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GTAWebsite.Models
{
    [Authorize(Roles ="Administrator")]
    public class Admin : Controller
    {
        public IActionResult Index() =>
         Content("Administrator");
    }
}
