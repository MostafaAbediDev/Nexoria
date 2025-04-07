using _0_FrameWork.Infrastructure;
using PortFolioManagement.Application.Contracts.PortFolioCategory;
using PortFolioManagement.Domain.PortFolioCategoryAgg;

namespace PortFolioManagement.Infrastructure.EFCore.Repository
{
    public class PortFolioCategoryRepository : RepositoryBase<long, PortFolioCategory>, IPortFolioCategoryRepository
    {
        private readonly PortFolioContext _context;

        public PortFolioCategoryRepository(PortFolioContext context) :base(context)
        {
            _context = context;
        }

        public EditPortFolioCategory GetDetails(long id)
        {
            return _context.PortFolioCategories.Select(x => new EditPortFolioCategory()
            {
                Id = x.Id,
                Name = x.Name,
                ShortDescription = x.ShortDescription,
                Icon = x.Icon,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug,
                //PictureAlt = x.PictureAlt,
                //PictureTitle = x.PictureTitle,

            }).FirstOrDefault(x => x.Id == id);
        }

        public string GetNameById(long id)
        {
            return _context.PortFolioCategories.Select(x => new { x.Id, x.Name }).FirstOrDefault(x => x.Id == id).Name;
        }

        public List<PortFolioCategoryViewModel> GetPortFolioCategories()
        {
            return _context.PortFolioCategories.Select(x => new PortFolioCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ShortDescription = x.ShortDescription,
                Icon = x.Icon,
            }).ToList();
        }

        public List<PortFolioCategoryViewModel> Search(PortFolioCategorySearchModel searchModel)
        {
            var query = _context.PortFolioCategories.Select(x => new PortFolioCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ShortDescription = x.ShortDescription,
                Icon = x.Icon,
                CreationDate = x.CreationDate.ToString()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
