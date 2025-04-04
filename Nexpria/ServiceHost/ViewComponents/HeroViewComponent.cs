using _01_NexoraiQuery.Contract.Hero;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class HeroViewComponent : ViewComponent
    {
        private readonly IHeroQuery _heroQuery;

        public HeroViewComponent(IHeroQuery heroQuery)
        {
            _heroQuery = heroQuery;
        }

        public IViewComponentResult Invoke()
        {
            var Heros = _heroQuery.GetHeros();
            return View(Heros);
        }
    }
}
