using PortFolioManagement.Application.Contracts.PortFolioCategory;

namespace PortFolioManagement.Application.Contracts.PortFolio
{
    public class CreatePortFolio
    {
        public string Title { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public long CategoryId { get; set; }
        public List<PortFolioCategoryViewModel> Categories { get; set; }
    }
}
