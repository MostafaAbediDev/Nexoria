namespace PortFolioManagement.Application.Contracts.About
{
    public class AboutViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public long ProjectsCompleted { get; set; }
        public long HappyClients { get; set; }
        public long YearsExperience { get; set; }
        public string CreationDate { get; set; }
    }
}
