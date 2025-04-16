using _01_NexoraiQuery.Contract.PortFolio;
using _01_NexoraiQuery.Contract.ProjectModal;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProjectModalViewComponent : ViewComponent
    {
        public ProjectQueryModel Modal;
        private readonly IProjectQuery _projectQuery;

        public ProjectModalViewComponent(IProjectQuery projectQuery)
        {
            _projectQuery = projectQuery;
        }

        public IViewComponentResult Invoke()
        {
            Modal = _projectQuery.GetProjects();         
            return View(Modal);
            
        }
    }
}
