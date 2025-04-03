using _0_FrameWork.Domain;
using PortFolioManagement.Application.Contracts.PortFolio;

namespace PortFolioManagement.Domain.PortFolioAgg
{
    public interface IPortFolioRepository : IRepository<long, PortFolio>
    {
        EditPortFolio GetDetails(long id);
        PortFolio GetPortFoliosWithCategory(long id);
        List<PortFolioViewModel> GetPortFolios();
        List<PortFolioViewModel> Search(PortFolioSearchModel searchModel);
    }
}
