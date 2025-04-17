namespace _01_NexoraiQuery.Contract.ProjectModal
{
    public class ProjectQueryModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string Timeline { get; set; }
        public string Keywords { get; set; }
        public string Services { get; set; }
        public string Results { get; set; }
        public List<string> KeywordList { get; set; }
        public List<string> ServiceList { get; set; }
        public List<string> ResultList { get; set; }
        public string MetaDescription { get; set; }
        public long CategoryId { get; set; }
        public string Category { get; set; }
        public string Slug { get; set; }
    }
}
