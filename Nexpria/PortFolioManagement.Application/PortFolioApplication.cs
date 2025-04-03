using _0_Framework.Application;
using PortFolioManagement.Application.Contracts.PortFolio;
using PortFolioManagement.Domain.PortFolioAgg;

namespace PortFolioManagement.Application
{
    public class PortFolioApplication : IPortFolioApplication
    {
        private readonly IPortFolioRepository _portFolioRepository;

        public PortFolioApplication(IPortFolioRepository portFolioRepository)
        {
            _portFolioRepository = portFolioRepository;
        }

        public OperationResult Create(CreatePortFolio command)
        {
            var operation = new OperationResult();
            if(_portFolioRepository.Exists(x=>x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var PortFolio = new PortFolio(command.Title, command.Picture, command.PictureAlt,
                command.PictureTitle, command.CategoryId, command.ShortDescription, command.Description,
                slug, command.Keywords, command.MetaDescription);

            _portFolioRepository.Create(PortFolio);
            _portFolioRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditPortFolio command)
        {
            var operation = new OperationResult();
            var PortFolio = _portFolioRepository.Get(command.Id);
            if (PortFolio == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var slug = command.Slug.Slugify();

            if (_portFolioRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            PortFolio.Edit(command.Title, command.Picture, command.PictureAlt,
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
