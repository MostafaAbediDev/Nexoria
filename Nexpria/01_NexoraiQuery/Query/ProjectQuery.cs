using _01_NexoraiQuery.Contract.PortFolio;
using _01_NexoraiQuery.Contract.ProjectModal;
using Microsoft.EntityFrameworkCore;
using PortFolioManagement.Infrastructure.EFCore;

namespace _01_NexoraiQuery.Query
{
    public class ProjectQuery : IProjectQuery
    {
        private readonly PortFolioContext _context;

        public ProjectQuery(PortFolioContext context)
        {
            _context = context;
        }

        public ProjectQueryModel GetProjects()
        {
            return _context.PortFolios
                .Include(x => x.Category)
                .Select(x => new ProjectQueryModel
                {
                    Id = x.Id,
                    Category = x.Category.Name,
                    Title = x.Title,
                    MetaDescription = x.MetaDescription,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Description = x.Description,
                    Client = x.Client,
                    Timeline = x.Timeline,
                    Keywords = x.Keywords,
                    Slug = x.Slug,
                }).FirstOrDefault();
        }
    }
}

