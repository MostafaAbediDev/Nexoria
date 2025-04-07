using _0_Framework.Application;
using _0_FrameWork.Application;
using PortFolioManagement.Application.Contracts.Hero;
using PortFolioManagement.Domain.HeroAgg;

namespace PortFolioManagement.Application
{
    public class HeroApplication : IHeroApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IHeroRepository _heroRepository;

        public HeroApplication(IFileUploader fileUploader, IHeroRepository heroRepository)
        {
            _fileUploader = fileUploader;
            _heroRepository = heroRepository;
        }

        public OperationResult Create(CreateHero command)
        {
            var operation = new OperationResult();

            var picturePath = $"{command.Heading}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            var hero = new Hero(fileName, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Text, command.BtnText1,
                command.BtnText2, command.Link1, command.Link2);

            _heroRepository.Create(hero);
            _heroRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditHero command)
        {
            var operation = new OperationResult();
            var hero = _heroRepository.Get(command.Id);

            if(hero == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var picturePath = $"{command.Heading}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            hero.Edit(fileName, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Text, command.BtnText1,
                command.BtnText2, command.Link1, command.Link2);

            _heroRepository.SaveChanges();

            return operation.Succedded();
        }

        public EditHero GetDetails(long id)
        {
            return _heroRepository.GetDetails(id);
        }

        public HeroViewModel GetHero()
        {
            return _heroRepository.GetHero();
        }
    }
}
