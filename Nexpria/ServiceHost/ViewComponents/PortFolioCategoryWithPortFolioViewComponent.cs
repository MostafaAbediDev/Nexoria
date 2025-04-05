using _01_NexoraiQuery.Contract.PortFolioCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class PortFolioCategoryWithPortFolioViewComponent : ViewComponent
    {
        private readonly IPortFolioCategoryQuery _portFolioCategoryQuery;

        public PortFolioCategoryWithPortFolioViewComponent(IPortFolioCategoryQuery portFolioCategoryQuery)
        {
            _portFolioCategoryQuery = portFolioCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _portFolioCategoryQuery.GetPortFolioCategoriesWithPortFolios();
            return View(categories);
        }
    }
}
