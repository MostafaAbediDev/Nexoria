namespace PortFolioManagement.Application.Contracts.PortFolioCategory
{
    public class PortFolioCategoryViewModel 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Icon { get; set; }
        public string CreationDate { get; set; }
        public long PortFolioCount { get; set; }
    }
}
