using _0_FrameWork.Domain;
using PortFolioManagement.Application.Contracts.Hero;

namespace PortFolioManagement.Domain.HeroAgg
{
    public interface IHeroRepository : IRepository<long,  Hero>
    {
        EditHero GetDetails(long id);
        HeroViewModel GetHero();
    }
}
