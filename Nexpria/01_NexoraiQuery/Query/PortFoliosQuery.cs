using _01_NexoraiQuery.Contract.PortFolio;
using _01_NexoraiQuery.Contract.ProjectModal;
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
                    Category = x.Category.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ShortDescription = x.ShortDescrioption,
                    Description = x.Description,
                    Client = x.Client,
                    Timeline = x.Timeline,
                    Keywords = x.Keywords,
                    Slug = x.Slug,
                }).ToList();
        }

        //public PortFolioQueryModel GetProjects()
        //{
        //    var project = _context.PortFolios
        //        .Include(x => x.Category)
        //        .Select(x => new PortFolioQueryModel
        //        {
        //            Id = x.Id,
        //            Title = x.Title,
        //            Category = x.Category.Name,
        //            Picture = x.Picture,
        //            PictureAlt = x.PictureAlt,
        //            PictureTitle = x.PictureTitle,
        //            Description = x.Description,
        //            Client = x.Client,
        //            Timeline = x.Timeline,
        //            Keywords = x.Keywords,
        //            Slug = x.Slug,

        //        }).FirstOrDefault();

        //    project.KeywordList = project.Keywords.Split(",").ToList();
        //    return project;
        //}

        //public PortFolioQueryModel GetProjects(string slug)
        //{
        //    return _context.PortFolios
        //        .Include(x => x.Category)
        //        .Select(x => new PortFolioQueryModel
        //        {
        //            Id = x.Id,
        //            Category = x.Category.Name,
        //            Title = x.Title,
        //            MetaDescription = x.MetaDescription,
        //            Picture = x.Picture,
        //            PictureAlt = x.PictureAlt,
        //            PictureTitle = x.PictureTitle,
        //            Description = x.Description,
        //            Client = x.Client,
        //            Timeline = x.Timeline,
        //            Keywords = x.Keywords,
        //            Slug = x.Slug,
        //        }).FirstOrDefault(x => x.Slug == slug);
        //}
    }
}
