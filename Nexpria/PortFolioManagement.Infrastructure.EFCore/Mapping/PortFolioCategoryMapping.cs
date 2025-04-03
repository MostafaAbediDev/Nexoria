using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortFolioManagement.Domain.PortFolioCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortFolioManagement.Infrastructure.EFCore.Mapping
{
    public class PortFolioCategoryMapping : IEntityTypeConfiguration<PortFolioCategory>
    {
        public void Configure(EntityTypeBuilder<PortFolioCategory> builder)
        {
            builder.ToTable("PortFolioCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            //builder.Property(x => x.Picture).HasMaxLength(1000);
            //builder.Property(x => x.PictureAlt).HasMaxLength(255);
            //builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.Keywords).HasMaxLength(80).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();

            builder.HasMany(x => x.PortFolios)
               .WithOne(x => x.Category)
               .HasForeignKey(x => x.CategoryId);
        }
    }
}
