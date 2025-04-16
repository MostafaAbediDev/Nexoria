using _01_NexoraiQuery.Contract.About;
using PortFolioManagement.Infrastructure.EFCore;

namespace _01_NexoraiQuery.Query
{
    public class AboutQuery : IAboutQuery
    {
        private readonly PortFolioContext _portFolioContext;

        public AboutQuery(PortFolioContext portFolioContext)
        {
            _portFolioContext = portFolioContext;
        }

        public AboutQueryModel GetAbout()
        {
            return _portFolioContext.Abouts.Select(x => new AboutQueryModel
            {
                Text = x.Text,
                Description = x.Description,
                ProjectsCompleted = x.ProjectsCompleted,
                HappyClients = x.HappyClients,
                YearsExperience = x.YearsExperience,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
            }).FirstOrDefault();
        }
    }
}
