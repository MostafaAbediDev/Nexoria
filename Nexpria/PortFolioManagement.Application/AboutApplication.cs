using _0_Framework.Application;
using _0_FrameWork.Application;
using PortFolioManagement.Application.Contracts.About;
using PortFolioManagement.Domain.AboutAgg;

namespace PortFolioManagement.Application
{
    public class AboutApplication : IAboutApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IAboutRepository _aboutRepository;

        public AboutApplication(IFileUploader fileUploader, IAboutRepository aboutRepository)
        {
            _fileUploader = fileUploader;
            _aboutRepository = aboutRepository;
        }

        public OperationResult Create(CreateAbout command)
        {
            var operation = new OperationResult();

            var picturePath = "About";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            var about = new About(command.Text, command.Description, command.ProjectsCompleted, 
                command.HappyClients, command.YearsExperience, fileName, 
                command.PictureAlt, command.PictureTitle);

            _aboutRepository.Create(about);
            _aboutRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditAbout command)
        {
            var operation = new OperationResult();
            var about = _aboutRepository.Get(command.Id);

            if (about == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var picturePath = "About";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            about.Edit(command.Text, command.Description, command.ProjectsCompleted,
                command.HappyClients, command.YearsExperience, fileName,
                command.PictureAlt, command.PictureTitle);

            _aboutRepository.SaveChanges();

            return operation.Succedded();
        }

        public AboutViewModel GetAbout()
        {
            return _aboutRepository.GetAbout();
        }

        public EditAbout GetDetails(long id)
        {
            return _aboutRepository.GetDetails(id);
        }
    }
}
