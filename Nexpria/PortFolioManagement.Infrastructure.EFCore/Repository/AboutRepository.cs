using _0_FrameWork.Infrastructure;
using PortFolioManagement.Application.Contracts.About;
using PortFolioManagement.Application.Contracts.Hero;
using PortFolioManagement.Domain.AboutAgg;

namespace PortFolioManagement.Infrastructure.EFCore.Repository
{
    public class AboutRepository : RepositoryBase<long, About>, IAboutRepository
    {
        private readonly PortFolioContext _context;

        public AboutRepository(PortFolioContext context) : base(context)
        {
            _context = context;
        }
        public AboutViewModel GetAbout()
        {
            var about = _context.Abouts.Select(x => new AboutViewModel
            {
                Id = x.Id,
                Text = x.Text,
                Description = x.Description,
                HappyClients = x.HappyClients,
                ProjectsCompleted = x.ProjectsCompleted,
                YearsExperience = x.YearsExperience,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToString()
            }).OrderByDescending(x => x.Id).FirstOrDefault();

            return about ?? new AboutViewModel { };
        }

        public EditAbout GetDetails(long id)
        {
            return _context.Abouts.Select(x => new EditAbout
            {
                Id = x.Id,
                Text = x.Text,
                Description = x.Description,
                HappyClients = x.HappyClients,
                ProjectsCompleted = x.ProjectsCompleted,
                YearsExperience = x.YearsExperience,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
