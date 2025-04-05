using _01_NexoraiQuery.Contract.PortFolio;
using _01_NexoraiQuery.Contract.PortFolioCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class PortFolioViewComponent : ViewComponent
    {
        private readonly IPortFolioQuery _portFolioQuery;

        public PortFolioViewComponent(IPortFolioQuery portFolioQuery)
        {
            _portFolioQuery = portFolioQuery;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _portFolioQuery.GetPortFolios();
            return View(categories);
        }
    }
}
