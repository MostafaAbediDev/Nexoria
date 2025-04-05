using _01_NexoraiQuery.Contract.PortFolio;

namespace _01_NexoraiQuery.Contract.PortFolioCategory
{
    public class PortFolioCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        //public string Keywords { get;  set; }
        //public string MetaDescription { get;  set; }
        public string Icon { get; set; }
        public string Slug { get; set; }
        public List<PortFolioQueryModel> PortFolios { get; set; }
    }
}
