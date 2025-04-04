using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortFolioManagement.Domain.HeroAgg;

namespace PortFolioManagement.Infrastructure.EFCore.Mapping
{
    public class HeroMapping : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> builder)
        {
            builder.ToTable("Heros");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Heading).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(255);
            builder.Property(x => x.BtnText1).HasMaxLength(50).IsRequired();
            builder.Property(x => x.BtnText2).HasMaxLength(50).IsRequired();

        }
    }
}
