using _0_FrameWork.Infrastructure;
using PortFolioManagement.Application.Contracts.Hero;
using PortFolioManagement.Domain.HeroAgg;

namespace PortFolioManagement.Infrastructure.EFCore.Repository
{
    public class HeroRepository : RepositoryBase<long, Hero>, IHeroRepository
    {
        private readonly PortFolioContext _context;

        public HeroRepository(PortFolioContext context) : base(context) 
        {
            _context = context;
        }

        public EditHero GetDetails(long id)
        {
            return _context.heroes.Select(x => new EditHero
            {
                Id = x.Id,
                BtnText1 = x.BtnText1,
                BtnText2 = x.BtnText2,
                Heading = x.Heading,
                Link1 = x.Link1,
                Link2 = x.Link2,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }

        public HeroViewModel GetHero()
        {
            var heros =  _context.heroes.Select(x => new HeroViewModel
            {
                Id = x.Id,
                Heading = x.Heading,
                Link1 = x.Link1,
                Link2 = x.Link2,
                Picture = x.Picture,
                Text = x.Text,
                CreationDate = x.CreationDate.ToString()
            }).OrderByDescending(x => x.Id).FirstOrDefault();

            return heros ?? new HeroViewModel { };
        }
    }
}
