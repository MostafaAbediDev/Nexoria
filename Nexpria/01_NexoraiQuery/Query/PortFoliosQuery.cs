using _01_NexoraiQuery.Contract.PortFolio;
using Microsoft.EntityFrameworkCore;
using PortFolioManagement.Infrastructure.EFCore;

namespace _01_NexoraiQuery.Query
{
    public class PortFoliosQuery : IPortFolioQuery
    {
        private readonly PortFolioContext _context;

        public PortFoliosQuery(PortFolioContext context)
        {
            _context = context;
        }

        public List<PortFolioQueryModel> GetPortFolios()
        {
            return _context.PortFolios
                .Include(x => x.Category)
                .Select(x => new PortFolioQueryModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ShortDescription = x.ShortDescrioption,
                }).ToList();
        }
    }
}
