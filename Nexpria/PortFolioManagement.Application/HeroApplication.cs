using _0_Framework.Application;
using PortFolioManagement.Application.Contracts.Hero;
using PortFolioManagement.Domain.HeroAgg;

namespace PortFolioManagement.Application
{
    public class HeroApplication : IHeroApplication
    {
        private readonly IHeroRepository _heroRepository;

        public HeroApplication(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public OperationResult Create(CreateHero command)
        {
            var operation = new OperationResult();

            var Hero = new Hero(command.Picture, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Text, command.Link1, command.Link2,command.BtnText1, command.BtnText2);

            _heroRepository.Create(Hero);
            _heroRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditHero command)
        {
            var operation = new OperationResult();
            var Hero = _heroRepository.Get(command.Id);
            if(Hero == null) 
                return operation.Failed(ApplicationMessages.RecordNotFound);

            Hero.Edit(command.Picture, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Text, command.Link1, command.Link2, command.BtnText1, command.BtnText2);

            
            _heroRepository.SaveChanges();

            return operation.Succedded();
        }

        public EditHero GetDetails(long id)
        {
            return _heroRepository.GetDetails(id);
        }

        public HeroViewModel GetHeros()
        {
            return _heroRepository.GetHeros();
        }
    }
}
