using HelioApp.Domain.Entities.Services___Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Service_Categories
{
    public sealed class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(s => s.Id);

            // Foreign keys & relations
            builder.HasOne(s => s.Provider)
                   .WithMany()
                   .HasForeignKey(s => s.ProviderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Subcategory)
                   .WithMany()
                   .HasForeignKey(s => s.SubcategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Properties
            builder.Property(s => s.Title).IsRequired();
            builder.Property(s => s.Description).IsRequired();
            builder.Property(s => s.Address).IsRequired();

            builder.Property(s => s.LocationLat);
            builder.Property(s => s.LocationLng);

            builder.Property(s => s.Phone).IsRequired();
            builder.Property(s => s.Whatsapp);
            builder.Property(s => s.Email);
            builder.Property(s => s.WebsiteUrl);

            builder.Property(s => s.CoverImageUrl);

            // JSON columns for Images and WorkingHours
            builder.Property(s => s.Images)
                .HasColumnType("nvarchar(max)");

            builder.Property(s => s.WorkingHours)
                .HasColumnType("nvarchar(max)");

            builder.Property(s => s.IsVerified).HasDefaultValue(false);

            builder.Property(s => s.Status)
                .HasConversion<byte>();

            builder.Property(s => s.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(s => s.UpdatedAt);
            builder.Property(s => s.DeletedAt);
        }
    }
}
