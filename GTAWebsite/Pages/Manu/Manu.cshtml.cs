using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GTAWebsite.Models.Manu;

namespace GTAWebsite.Pages.ManuModel
{
   
    public class ManuModel : PageModel
    {
        [BindProperty]
        public ManuModel Manu { get; set; }
        public void OnGet()
        {
            Manu = new ManuModel();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();  
            }
            return RedirectToPage("Index");
        }
    }
}
