using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortFolioManagement.Application.Contracts.PortFolio;
using PortFolioManagement.Application.Contracts.PortFolioCategory;
using PortFolioManagement.Domain.PortFolioAgg;

namespace ServiceHost.Areas.Administration.Pages.PortFolio.PortFolios
{
    public class IndexModel : PageModel
    {
        public PortFolioSearchModel SearchModel;
        public List<PortFolioViewModel> PortFolios;
        public SelectList PortFolioCategories;

        private readonly IPortFolioApplication _portFolioApplication;

        private readonly IPortFolioCategoryApplication _portFolioCategoryApplication;

        public IndexModel(IPortFolioApplication portFolioApplication, IPortFolioCategoryApplication portFolioCategoryApplication)
        {
            _portFolioApplication = portFolioApplication;
            _portFolioCategoryApplication = portFolioCategoryApplication;
        }

        public void OnGet(PortFolioSearchModel searchModel)
        {
            PortFolioCategories = new SelectList(_portFolioCategoryApplication.GetPortFolioCategories(), "Id", "Name");
            PortFolios = _portFolioApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreatePortFolio();
            command.Categories = _portFolioCategoryApplication.GetPortFolioCategories();

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreatePortFolio command) 
        {
            var result = _portFolioApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var portFolio = _portFolioApplication.GetDetails(id);
            portFolio.Categories = _portFolioCategoryApplication.GetPortFolioCategories();

            return Partial("./Edit", portFolio);
        }

        public JsonResult OnPostEdit(EditPortFolio command)
        {
            if (ModelState.IsValid)
            {
                
            }
            var result = _portFolioApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
