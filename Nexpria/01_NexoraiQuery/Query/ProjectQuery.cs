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

        public ProjectQueryModel GetProjectById(long id)
        {
            var project = _context.PortFolios
                .Include(x => x.Category)
                .Select(x => new ProjectQueryModel
                {
                    Id = x.Id,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Title = x.Title,
                    Keywords = x.Keywords,
                    Description = x.Description,
                    Client = x.Client,
                    Timeline = x.Timeline,
                    Services = x.Services,
                    Results = x.Results,
                    MetaDescription = x.MetaDescription,
                    Slug = x.Slug,
                }).FirstOrDefault(x => x.Id == id);


            if (!string.IsNullOrWhiteSpace(project.Keywords))
            {
                project.KeywordList = project.Keywords
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(k => k.Trim())
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(project.Services))
            {
                project.ServiceList = project.Services
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(k => k.Trim())
                    .ToList();
            }


            if (!string.IsNullOrWhiteSpace(project.Results))
            {
                project.ResultList = project.Results
                    .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }



            return project;
        }

    }
}

