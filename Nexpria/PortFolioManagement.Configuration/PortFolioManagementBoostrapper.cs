using _01_NexoraiQuery.Contract.About;
using _01_NexoraiQuery.Contract.Hero;
using _01_NexoraiQuery.Contract.PortFolio;
using _01_NexoraiQuery.Contract.PortFolioCategory;
using _01_NexoraiQuery.Contract.ProjectModal;
using _01_NexoraiQuery.Query;
using PortFolioManagement.Application;
using PortFolioManagement.Application.Contracts.Comment;
using PortFolioManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortFolioManagement.Application.Contracts.About;
using PortFolioManagement.Application.Contracts.Hero;
using PortFolioManagement.Application.Contracts.PortFolio;
using PortFolioManagement.Application.Contracts.PortFolioCategory;
using PortFolioManagement.Domain.AboutAgg;
using PortFolioManagement.Domain.HeroAgg;
using PortFolioManagement.Domain.PortFolioAgg;
using PortFolioManagement.Domain.PortFolioCategoryAgg;
using PortFolioManagement.Infrastructure.EFCore;
using PortFolioManagement.Infrastructure.EFCore.Repository;

namespace PortFolioManagement.Configuration
{
    public class PortFolioManagementBoostrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IPortFolioCategoryRepository, PortFolioCategoryRepository>();
            services.AddTransient<IPortFolioCategoryApplication, PortFolioCategoryApplication>();

            services.AddTransient<IPortFolioRepository, PortFolioRepository>();
            services.AddTransient<IPortFolioApplication, PortFolioApplication>();

            services.AddTransient<IHeroApplication, HeroApplication>();
            services.AddTransient<IHeroRepository, HeroRepository>();

            services.AddTransient<IAboutApplication, AboutApplication>();
            services.AddTransient<IAboutRepository, AboutRepository>();

            services.AddTransient<ICommentApplication, CommentApplication>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddTransient<IHeroQuery, HeroQuery>();
            services.AddTransient<IAboutQuery, AboutQuery>();
            services.AddTransient<IPortFolioCategoryQuery, PortFolioCategoryQuery>();
            services.AddTransient<IPortFolioQuery, PortFoliosQuery>();
            services.AddTransient<IProjectQuery, ProjectQuery>();

            services.AddDbContext<PortFolioContext>(x=>x.UseSqlServer(connectionString));
        }
    }
}
