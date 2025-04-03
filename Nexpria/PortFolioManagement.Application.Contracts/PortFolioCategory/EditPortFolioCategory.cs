
namespace PortFolioManagement.Application.Contracts.PortFolioCategory
{
    public class EditPortFolioCategory : CreatePortFolioCategory
    {
        public long Id { get; set; }
        public List<PortFolioCategoryViewModel> Categories { get; set; }
    }
}
