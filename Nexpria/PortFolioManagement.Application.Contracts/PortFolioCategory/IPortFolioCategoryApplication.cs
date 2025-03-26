using _0_Framework.Application;

namespace PortFolioManagement.Application.Contracts.PortFolioCategory
{
    public interface IPortFolioCategoryApplication
    {
        OperationResult Create(CreatePortFolioCategory command);
        OperationResult Edit(EditPortFolioCategory command);
        EditPortFolioCategory GetDetails(long id);
        List<PortFolioCategoryViewModel> Search(PortFolioCategorySearchModel searchModel);
        List<PortFolioCategoryViewModel> GetPortFolioCategory();
    }
}
