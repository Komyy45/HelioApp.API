using HelioApp.Domain.Entities.CityServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.CityServices
{
    public sealed class CityServiceConfiguration : IEntityTypeConfiguration<CityService>
    {
        public void Configure(EntityTypeBuilder<CityService> builder)
        {
            builder.ToTable("CityServices");

            builder.HasKey(cs => cs.Id);

            builder.Property(cs => cs.Id).HasColumnName("id");
            builder.Property(cs => cs.Title).HasColumnName("title").IsRequired();
            builder.Property(cs => cs.TitleAr).HasColumnName("title_ar");
            builder.Property(cs => cs.Description).HasColumnName("description");

            builder.Property(cs => cs.Category).HasColumnName("category");
            builder.Property(cs => cs.IconUrl).HasColumnName("icon_url");
            builder.Property(cs => cs.Slap).HasColumnName("slap");
            builder.Property(cs => cs.DocumentUrl).HasColumnName("document_url");

            builder.Property(cs => cs.ContactPhone).HasColumnName("contact_phone");
            builder.Property(cs => cs.ContactEmail).HasColumnName("contact_email");
            builder.Property(cs => cs.WebsiteUrl).HasColumnName("website_url");

            builder.Property(cs => cs.Location).HasColumnName("location");

            builder.Property(cs => cs.WorkingHours)
                   .HasColumnName("working_hours")
                   .HasColumnType("nvarchar(max)"); 

            builder.Property(cs => cs.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(cs => cs.DisplayOrder).HasColumnName("display_order").HasDefaultValue(0);

            builder.Property(cs => cs.CreatedAt)
                   .HasColumnName("created_at")
                   .HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(cs => cs.UpdatedAt)
                   .HasColumnName("updated_at")
                   .HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
