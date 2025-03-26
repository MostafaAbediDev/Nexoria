namespace PortFolioManagement.Application.Contracts.PortFolioCategory
{
    public class PortFolioCategoryViewModel 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string CreationDate { get; set; }
        public long PortFolioCount { get; set; }
    }
}
