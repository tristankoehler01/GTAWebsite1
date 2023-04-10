using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GTAWebsite.Models
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller {
        public IActionResult Index() =>
        Content("Student");
    }
}
