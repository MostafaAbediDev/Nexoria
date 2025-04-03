using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortFolioManagement.Application.Contracts.PortFolioCategory;


namespace ServiceHost.Areas.Administration.Pages.PortFolio.PortFolioCategory
{
    public class IndexModel : PageModel
    {
        public PortFolioCategorySearchModel SearchModel;
        public List<PortFolioCategoryViewModel> PortFolioCategories;
        
        private readonly IPortFolioCategoryApplication _portFolioCategoryApplication;

        public IndexModel(IPortFolioCategoryApplication portFolioCategoryApplication)
        {
            _portFolioCategoryApplication = portFolioCategoryApplication;
        }

        public void OnGet(PortFolioCategorySearchModel searchModel)
        {
            PortFolioCategories = _portFolioCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreatePortFolioCategory());
        }

        public JsonResult OnPostCreate(CreatePortFolioCategory command) 
        {
            var result = _portFolioCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var portFolioCategory = _portFolioCategoryApplication.GetDetails(id);
            return Partial("./Edit", portFolioCategory);
        }

        public JsonResult OnPostEdit(EditPortFolioCategory command)
        {
            var result = _portFolioCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
