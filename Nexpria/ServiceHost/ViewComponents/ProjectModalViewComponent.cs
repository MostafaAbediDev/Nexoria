using _01_NexoraiQuery.Contract.PortFolio;
using _01_NexoraiQuery.Contract.ProjectModal;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProjectModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
            
        }
    }
}
