using HelioApp.Domain.Entities.CityServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.CityServices
{
    public sealed class EmergencyContactConfiguration : IEntityTypeConfiguration<EmergencyContact>
    {
        public void Configure(EntityTypeBuilder<EmergencyContact> builder)
        {
            builder.ToTable("EmergencyContacts");

            builder.HasKey(ec => ec.Id);

            builder.Property(ec => ec.Id).HasColumnName("id");
            builder.Property(ec => ec.Title).HasColumnName("title").IsRequired();
            builder.Property(ec => ec.TitleAr).HasColumnName("title_ar");

            builder.Property(ec => ec.Type).HasColumnName("type").IsRequired();

            builder.Property(ec => ec.Number).HasColumnName("number").IsRequired();
            builder.Property(ec => ec.SecondaryNumber).HasColumnName("secondary_number");

            builder.Property(ec => ec.Description).HasColumnName("description");

            builder.Property(ec => ec.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(ec => ec.DisplayOrder).HasColumnName("display_order").HasDefaultValue(0);

            builder.Property(ec => ec.CreatedAt)
                   .HasColumnName("created_at")
                   .HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(ec => ec.UpdatedAt)
                   .HasColumnName("updated_at")
                   .HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}