using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages
{
    public class AdminModel : PageModel
    {
        [BindProperty] public string Username { get; set; }
        [BindProperty] public string Password { get; set; }
        [BindProperty(SupportsGet = true)] public string? ReturnUrl { get; set; }

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (Username == "admin" && Password == "1234")
            {
                // اطلاعات ورود صحیح است، ارسال اطلاعات در QueryString
                return Redirect($"{ReturnUrl}?u={Username}&p={Password}");
            }

            ErrorMessage = "نام کاربری یا رمز اشتباه است.";
            return Page();
        }

    }
}
