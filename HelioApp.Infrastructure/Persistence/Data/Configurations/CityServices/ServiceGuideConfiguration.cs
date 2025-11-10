using HelioApp.Domain.Entities.CityServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.CityServices
{
    public sealed class ServiceGuideConfiguration : IEntityTypeConfiguration<ServiceGuide>
    {
        public void Configure(EntityTypeBuilder<ServiceGuide> builder)
        {
            builder.ToTable("ServiceGuides");

            builder.HasKey(sg => sg.Id);

            builder.Property(sg => sg.Id).HasColumnName("id");
            builder.Property(sg => sg.Title).HasColumnName("title").IsRequired();
            builder.Property(sg => sg.TitleAr).HasColumnName("title_ar");

            builder.Property(sg => sg.Content).HasColumnName("content").IsRequired();

            builder.Property(sg => sg.Category).HasColumnName("category");
            builder.Property(sg => sg.IconUrl).HasColumnName("icon_url");
            builder.Property(sg => sg.PdfUrl).HasColumnName("pdf_url");

            builder.Property(sg => sg.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(sg => sg.DisplayOrder).HasColumnName("display_order").HasDefaultValue(0);
            builder.Property(sg => sg.ViewCount).HasColumnName("view_count").HasDefaultValue(0);

            builder.Property(sg => sg.CreatedAt)
                   .HasColumnName("created_at")
                   .HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(sg => sg.UpdatedAt)
                   .HasColumnName("updated_at")
                   .HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}

