using _0_Framework.Application;

namespace PortFolioManagement.Application.Contracts.Hero
{
    public interface IHeroApplication
    {
        OperationResult Create(CreateHero command);
        OperationResult Edit(EditHero command);
        EditHero GetDetails(long id);
        HeroViewModel GetHero();
    }
}
