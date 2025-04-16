using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortFolioManagement.Domain.PortFolioAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortFolioManagement.Infrastructure.EFCore.Mapping
{
    public class PortFolioMapping : IEntityTypeConfiguration<PortFolio>
    {
        public void Configure(EntityTypeBuilder<PortFolio> builder) 
        {
            builder.ToTable("PortFolios");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
            builder.Property(x => x.ShortDescrioption).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(255);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);

            builder.Property(x => x.Keywords).HasMaxLength(100).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Client).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Timeline).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.PortFolios)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
