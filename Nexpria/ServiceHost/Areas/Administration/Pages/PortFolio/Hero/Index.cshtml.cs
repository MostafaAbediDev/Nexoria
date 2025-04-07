using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortFolioManagement.Application.Contracts.Hero;

namespace ServiceHost.Areas.Administration.Pages.PortFolio.Hero
{
    public class IndexModel : PageModel
    {
        public HeroViewModel Heros;

        private readonly IHeroApplication _heroApplication;

        public IndexModel(IHeroApplication heroApplication)
        {
            _heroApplication = heroApplication;
        }

        public void OnGet()
        {
            Heros = _heroApplication.GetHero();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateHero();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateHero command)
        {
            var result = _heroApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var heros = _heroApplication.GetDetails(id);

            return Partial("./Edit", heros);
        }

        public JsonResult OnPostEdit(EditHero command)
        {   
            var result = _heroApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
