using _01_NexoraiQuery.Contract.About;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IAboutQuery _aboutQuery;

        public AboutViewComponent(IAboutQuery aboutQuery)
        {
            _aboutQuery = aboutQuery;
        }

        public IViewComponentResult Invoke()
        {
            var About = _aboutQuery.GetAbout();
            return View(About);
        }
    }
}
