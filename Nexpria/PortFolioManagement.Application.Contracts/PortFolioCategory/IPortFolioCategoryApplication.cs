using _0_Framework.Application;
using System.Collections.Generic;

namespace PortFolioManagement.Application.Contracts.PortFolioCategory
{
    public interface IPortFolioCategoryApplication
    {
        OperationResult Create(CreatePortFolioCategory command);
        OperationResult Edit(EditPortFolioCategory command);
        EditPortFolioCategory GetDetails(long id);
        List<PortFolioCategoryViewModel> GetPortFolioCategories();
        List<PortFolioCategoryViewModel> Search(PortFolioCategorySearchModel searchModel);
    }
}
