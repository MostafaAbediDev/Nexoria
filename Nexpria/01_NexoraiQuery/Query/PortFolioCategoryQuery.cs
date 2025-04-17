using _01_NexoraiQuery.Contract.PortFolio;
using _01_NexoraiQuery.Contract.PortFolioCategory;
using Microsoft.EntityFrameworkCore;
using PortFolioManagement.Domain.PortFolioAgg;
using PortFolioManagement.Infrastructure.EFCore;

namespace _01_NexoraiQuery.Query
{
    public class PortFolioCategoryQuery : IPortFolioCategoryQuery
    {
        private readonly PortFolioContext _context;

        public PortFolioCategoryQuery(PortFolioContext context)
        {
            _context = context;
        }

        public List<PortFolioCategoryQueryModel> GetPortFolioCategories()
        {
            return _context.PortFolioCategories.Select(x => new PortFolioCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                ShortDescription = x.ShortDescription,
                Icon = x.Icon,
                Slug = x.Slug
            }).ToList();
        }

        //public PortFolioCategoryQueryModel GetPortFolioCategoryWithPortFolio()
        //{
        //    return _context.PortFolioCategories
        //        .Include(x => x.PortFolios)
        //        .ThenInclude(x => x.Category)
        //        .Select(x => new PortFolioCategoryQueryModel
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            ShrtDescription = x.ShortDescription,
        //            Keywords = x.Keywords,
        //            MetaDescription = x.MetaDescription,
        //            PortFolios = MapPortFolios(x.PortFolios)
        //        }).FirstOrDefault();
        //}

        public List<PortFolioCategoryQueryModel> GetPortFolioCategoriesWithPortFolios()
        {
            return _context.PortFolioCategories
                .Include(x => x.PortFolios)
                .ThenInclude(x => x.Category)
                .Select(x => new PortFolioCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ShortDescription= x.ShortDescription,
                    Keywords = x.Keywords,
                    PortFolios = MapPortFolios(x.PortFolios),
                }).ToList();

        }

        private static List<PortFolioQueryModel> MapPortFolios(List<PortFolio> portFolios)
        {
            var result = new List<PortFolioQueryModel>();
            foreach (var portFolio in portFolios)
            {
                var item = new PortFolioQueryModel
                {
                    Id = portFolio.Id,
                    Category = portFolio.Category.Name,
                    Title = portFolio.Title,
                    Picture = portFolio.Picture,
                    PictureAlt = portFolio.PictureAlt,
                    PictureTitle = portFolio.PictureTitle,
                    Keywords= portFolio.Keywords,
                    ShortDescription = portFolio.ShortDescrioption,
                    Slug = portFolio.Slug
                };
                result.Add(item);

                if (!string.IsNullOrWhiteSpace(item.Keywords))
                {
                    item.KeywordList = item.Keywords
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(k => k.Trim())
                    .ToList();
                }
            }
            return result;
        }
    }
}
