using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortFolioManagement.Application.Contracts.Comment;


namespace ServiceHost.Pages
{
    public class ContactModel : PageModel
    {
        
        private readonly ICommentApplication _commentApplication;

        public ContactModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(AddComment command)
        {
            var result = _commentApplication.Add(command);
            return new RedirectToPageResult("./Contact");
        }
    }
}
