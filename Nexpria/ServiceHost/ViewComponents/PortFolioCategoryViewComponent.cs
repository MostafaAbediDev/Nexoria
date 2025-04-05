using _01_NexoraiQuery.Contract.PortFolioCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class PortFolioCategoryViewComponent : ViewComponent
    {
        private readonly IPortFolioCategoryQuery _portFolioCategoryQuery;

        public PortFolioCategoryViewComponent(IPortFolioCategoryQuery portFolioCategoryQuery)
        {
            _portFolioCategoryQuery = portFolioCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var portFolioCategories = _portFolioCategoryQuery.GetPortFolioCategories();
            return View(portFolioCategories);
        }
    }
}
