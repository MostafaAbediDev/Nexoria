using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages
{
    public class AdminPageModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Username == "NexoriaTeam" && Password == "NexoriaASHM12345$")
            {
                HttpContext.Session.SetString("AdminAuthenticated", "true");

                return Redirect("/Administration");
            }

            ErrorMessage = "The username or password is incorrect!";
            return Page();
        }
    }
}

