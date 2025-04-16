using _0_FrameWork.Domain;
using PortFolioManagement.Application.Contracts.About;

namespace PortFolioManagement.Domain.AboutAgg
{
    public interface IAboutRepository : IRepository<long, About>
    {
        EditAbout GetDetails(long id);
        AboutViewModel GetAbout();
    }
}
