using _01_NexoraiQuery.Contract.Hero;
using PortFolioManagement.Infrastructure.EFCore;

namespace _01_NexoraiQuery.Query
{
    public class HeroQuery : IHeroQuery
    {
        private readonly PortFolioContext _portFolioContext;

        public HeroQuery(PortFolioContext portFolioContext)
        {
            _portFolioContext = portFolioContext;
        }

        public HeroQueryModel GetHeros()
        {
            return _portFolioContext.heroes.Select(x => new HeroQueryModel
            {
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                BtnText1 = x.BtnText1,
                BtnText2 = x.BtnText2,
                Heading = x.Heading,
                Link1 = x.Link1,
                Link2 = x.Link2,
                Text = x.Text,

            }).FirstOrDefault();
        }
    }
}
