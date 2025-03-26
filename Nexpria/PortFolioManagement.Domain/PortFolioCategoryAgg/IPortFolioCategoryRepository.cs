using _0_FrameWork.Domain;
using PortFolioManagement.Application.Contracts.PortFolioCategory;

namespace PortFolioManagement.Domain.PortFolioCategoryAgg
{
    public interface IPortFolioCategoryRepository : IRepository<long, PortFolioCategory>
    {
        EditPortFolioCategory GetDetails(long id);
        List<PortFolioCategoryViewModel> Search(PortFolioCategorySearchModel searchModel);
        List<PortFolioCategoryViewModel> GetPortFolioCategory();
    }
}
