using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortFolioManagement.Application;
using PortFolioManagement.Application.Contracts.PortFolio;
using PortFolioManagement.Application.Contracts.PortFolioCategory;
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


            services.AddDbContext<PortFolioContext>(x=>x.UseSqlServer(connectionString));
        }
    }
}
