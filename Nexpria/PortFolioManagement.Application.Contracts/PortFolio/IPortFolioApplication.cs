using _0_Framework.Application;

namespace PortFolioManagement.Application.Contracts.PortFolio
{
    public interface IPortFolioApplication
    {
        OperationResult Create(CreatePortFolio command);
        OperationResult Edit(EditPortFolio command);
        OperationResult Removed(long id);
        OperationResult NotRemoved(long id);
        EditPortFolio GetDetails(long id);
        List<PortFolioViewModel> Search(PortFolioSearchModel searchModel);
        List<PortFolioViewModel> GetPortFolios();

    }
}
