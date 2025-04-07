using _0_Framework.Application;
using _0_FrameWork.Application;
using PortFolioManagement.Application.Contracts.PortFolio;
using PortFolioManagement.Domain.PortFolioAgg;
using PortFolioManagement.Domain.PortFolioCategoryAgg;

namespace PortFolioManagement.Application
{
    public class PortFolioApplication : IPortFolioApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IPortFolioRepository _portFolioRepository;
        private readonly IPortFolioCategoryRepository _portFolioCategoryRepository;

        public PortFolioApplication(IFileUploader fileUploader, IPortFolioRepository portFolioRepository,
            IPortFolioCategoryRepository portFolioCategoryRepository)
        {
            _fileUploader = fileUploader;
            _portFolioRepository = portFolioRepository;
            _portFolioCategoryRepository = portFolioCategoryRepository;
        }

        public OperationResult Create(CreatePortFolio command)
        {
            var operation = new OperationResult();
            if(_portFolioRepository.Exists(x=>x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var categoryName = _portFolioCategoryRepository.GetNameById(command.CategoryId);
            var picturePath = $"{categoryName}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            var PortFolio = new PortFolio(command.Title, fileName, command.PictureAlt,
                command.PictureTitle, command.CategoryId, command.ShortDescription, command.Description,
                slug, command.Keywords, command.MetaDescription);

            _portFolioRepository.Create(PortFolio);
            _portFolioRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditPortFolio command)
        {
            var operation = new OperationResult();
            var PortFolio = _portFolioRepository.GetPortFolioWithCategory(command.Id);
            if (PortFolio == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);


            if (_portFolioRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var picturePath = $"{PortFolio.Category.Name}";

            var fileName = _fileUploader.Upload(command.Picture,picturePath);

            PortFolio.Edit(command.Title, fileName, command.PictureAlt,
                command.PictureTitle, command.CategoryId, command.ShortDescription, command.Description,
                slug, command.Keywords, command.MetaDescription);

            _portFolioRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditPortFolio GetDetails(long id)
        {
            return _portFolioRepository.GetDetails(id);
        }

        public List<PortFolioViewModel> GetPortFolios()
        {
            return _portFolioRepository.GetPortFolios();
        }

        public OperationResult NotRemoved(long id)
        {
            var operation = new OperationResult();
            var PortFolio = _portFolioRepository.Get(id);
            if (PortFolio == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            PortFolio.NotReoved();
            _portFolioRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Removed(long id)
        {
            var operation = new OperationResult();
            var PortFolio = _portFolioRepository.Get(id);
            if (PortFolio == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            PortFolio.Removed();
            _portFolioRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<PortFolioViewModel> Search(PortFolioSearchModel searchModel)
        {
            return _portFolioRepository.Search(searchModel);
        }
    }
}
