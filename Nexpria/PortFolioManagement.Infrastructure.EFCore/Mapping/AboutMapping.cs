using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortFolioManagement.Domain.AboutAgg;

namespace PortFolioManagement.Infrastructure.EFCore.Mapping
{
    public class AboutMapping : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("Abouts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(255);
            builder.Property(x => x.ProjectsCompleted).IsRequired();
            builder.Property(x => x.HappyClients).IsRequired();
            builder.Property(x => x.YearsExperience).IsRequired();
        }
    }
}
