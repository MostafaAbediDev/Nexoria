using _0_Framework.Application;
using PortFolioManagement.Application.Contracts.PortFolioCategory;
using PortFolioManagement.Domain.PortFolioCategoryAgg;

namespace PortFolioManagement.Application
{
    public class PortFolioCategoryApplication : IPortFolioCategoryApplication
    {
        private readonly IPortFolioCategoryRepository _portFolioCategoryRepository;

        public PortFolioCategoryApplication(IPortFolioCategoryRepository portFolioCategoryRepository)
        {
            _portFolioCategoryRepository = portFolioCategoryRepository;
        }

        public OperationResult Create(CreatePortFolioCategory command)
        {
            var opration = new OperationResult();
            if (_portFolioCategoryRepository.Exists(x => x.Name == command.Name))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var portFolioCategory = new PortFolioCategory(command.Name, command.Description
            , command.Keywords, command.MetaDescription, slug);

            _portFolioCategoryRepository.Create(portFolioCategory);
            _portFolioCategoryRepository.SaveChanges();

            return opration.Succedded();
        }

        public OperationResult Edit(EditPortFolioCategory command)
        {
            var operation = new OperationResult();

            var portFolioCategory = _portFolioCategoryRepository.Get(command.Id);
            if (portFolioCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_portFolioCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            portFolioCategory.Edit(command.Name, command.Description, command.Keywords, command.MetaDescription, slug);

            _portFolioCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditPortFolioCategory GetDetails(long id)
        {
            return _portFolioCategoryRepository.GetDetails(id);
        }

        public List<PortFolioCategoryViewModel> GetPortFolioCategories()
        {
            return _portFolioCategoryRepository.GetPortFolioCategories();
        }

        public List<PortFolioCategoryViewModel> Search(PortFolioCategorySearchModel searchModel)
        {
            return _portFolioCategoryRepository.Search(searchModel);
        }
    }
}
