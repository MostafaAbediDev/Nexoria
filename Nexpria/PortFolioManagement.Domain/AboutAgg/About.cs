using _0_FrameWork.Domain;
using Microsoft.AspNetCore.Http;

namespace PortFolioManagement.Domain.AboutAgg
{
    public class About : EntityBase
    {
        public string Text { get; private set; }
        public string Description { get; private set; }
        public long ProjectsCompleted { get; private set; }
        public long HappyClients { get; private set; }
        public long YearsExperience { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }

        protected About()
        {
            
        }
        public About(string text, string description, long projectsCompleted, 
            long happyClients, long yearsExperience, string picture, 
            string pictureAlt, string pictureTitle)
        {
            Text = text;
            Description = description;
            ProjectsCompleted = projectsCompleted;
            HappyClients = happyClients;
            YearsExperience = yearsExperience;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Edit(string text, string description, long projectsCompleted,
            long happyClients, long yearsExperience, string picture,
            string pictureAlt, string pictureTitle)
        {
            Text = text;
            Description = description;
            ProjectsCompleted = projectsCompleted;
            HappyClients = happyClients;
            YearsExperience = yearsExperience;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }
    }
}
