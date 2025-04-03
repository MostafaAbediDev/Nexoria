 namespace PortFolioManagement.Application.Contracts.PortFolio
{
    public class PortFolioViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string CreationDate { get; set; }
        public long CategoryId { get; set; }
    }
}
