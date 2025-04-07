using _01_NexoraiQuery.Contract.Hero;
using _01_NexoraiQuery.Contract.PortFolio;
using _01_NexoraiQuery.Contract.PortFolioCategory;
using _01_NexoraiQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortFolioManagement.Application;
using PortFolioManagement.Application.Contracts.Hero;
using PortFolioManagement.Application.Contracts.PortFolio;
using PortFolioManagement.Application.Contracts.PortFolioCategory;
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



            services.AddTransient<IHeroQuery, HeroQuery>();
            services.AddTransient<IPortFolioCategoryQuery, PortFolioCategoryQuery>();
            services.AddTransient<IPortFolioQuery, PortFoliosQuery>();

            services.AddDbContext<PortFolioContext>(x=>x.UseSqlServer(connectionString));
        }
    }
}
