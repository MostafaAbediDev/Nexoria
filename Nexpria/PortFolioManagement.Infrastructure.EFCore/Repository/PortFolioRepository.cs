using _0_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PortFolioManagement.Application.Contracts.PortFolio;
using PortFolioManagement.Domain.PortFolioAgg;

namespace PortFolioManagement.Infrastructure.EFCore.Repository
{
    public class PortFolioRepository : RepositoryBase<long, PortFolio>, IPortFolioRepository
    {
        private readonly PortFolioContext _context;

        public PortFolioRepository(PortFolioContext context) : base(context)
        {
            _context = context;
        }

        public EditPortFolio GetDetails(long id)
        {
            return _context.PortFolios.Select(x => new EditPortFolio
            {
                Id = x.Id,
                Title = x.Title,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Client = x.Client,
                Timeline = x.Timeline,
                Services = x.Services,
                Results = x.Results,
                ShortDescription = x.ShortDescrioption,
                Slug = x.Slug,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<PortFolioViewModel> GetPortFolios()
        {
            return _context.PortFolios.Select(x => new PortFolioViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Picture = x.Picture,
                Description = x.Description,
                ShortDescription = x.ShortDescrioption
            }).ToList();
        }

        public PortFolio GetPortFoliosWithCategory(long id)
        {
            return _context.PortFolios.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public PortFolio GetPortFolioWithCategory(long id)
        {
            return _context.PortFolios.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<PortFolioViewModel> Search(PortFolioSearchModel searchModel)
        {
            var query = _context.PortFolios.Include(x => x.Category)
                .Select(x => new PortFolioViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Picture = x.Picture,
                    Category = x.Category.Name,
                    CategoryId = x.CategoryId,
                    Description = x.Description,
                    ShortDescription = x.ShortDescrioption,
                    CreationDate = x.CreationDate.ToString()
                });
            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
