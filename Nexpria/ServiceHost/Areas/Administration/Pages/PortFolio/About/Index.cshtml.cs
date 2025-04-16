using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortFolioManagement.Application.Contracts.About;

namespace ServiceHost.Areas.Administration.Pages.PortFolio.About
{
    public class IndexModel : PageModel
    {
        public AboutViewModel Abouts;

        private readonly IAboutApplication _aboutApplication;

        public IndexModel(IAboutApplication aboutApplication)
        {
            _aboutApplication = aboutApplication;
        }

        public void OnGet()
        {
            Abouts = _aboutApplication.GetAbout();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateAbout();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateAbout command)
        {
            var result = _aboutApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var abouts = _aboutApplication.GetDetails(id);

            return Partial("./Edit", abouts);
        }

        public JsonResult OnPostEdit(EditAbout command)
        {
            var result = _aboutApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
