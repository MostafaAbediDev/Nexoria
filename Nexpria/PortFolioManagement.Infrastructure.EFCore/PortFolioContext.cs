using Microsoft.EntityFrameworkCore;
using PortFolioManagement.Domain.AboutAgg;
using PortFolioManagement.Domain.CommentAgg;
using PortFolioManagement.Domain.HeroAgg;
using PortFolioManagement.Domain.PortFolioAgg;
using PortFolioManagement.Domain.PortFolioCategoryAgg;

namespace PortFolioManagement.Infrastructure.EFCore
{
    public class PortFolioContext : DbContext
    {
        public DbSet<PortFolioCategory> PortFolioCategories { get; set; }
        public DbSet<PortFolio> PortFolios { get; set; }    
        public DbSet<Hero> heroes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<About> Abouts { get; set; }
        public PortFolioContext(DbContextOptions<PortFolioContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(PortFolioContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
