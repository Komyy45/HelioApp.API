using HelioApp.Domain.Entities.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Properties
{
    public sealed class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Properties");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.OwnerId).HasColumnName("owner_id").IsRequired();

            builder.HasOne(p => p.Owner)
                   .WithMany()
                   .HasForeignKey(p => p.OwnerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Title).HasColumnName("title").IsRequired();
            builder.Property(p => p.Description).HasColumnName("description").IsRequired();

            builder.Property(p => p.PropertyType)
                   .HasColumnName("property_type")
                   .HasConversion<byte>()
                   .IsRequired();

            builder.Property(p => p.Price).HasColumnName("price").IsRequired();

            builder.Property(p => p.Location).HasColumnName("location").IsRequired();

            builder.Property(p => p.Amenities)
                   .HasColumnName("amenities")
                   .HasColumnType("nvarchar(max)");

            builder.Property(p => p.Images)
                   .HasColumnName("images")
                   .HasColumnType("nvarchar(max)")
                   .IsRequired();

            builder.Property(p => p.ContactName).HasColumnName("contact_name").IsRequired();
            builder.Property(p => p.ContactPhone).HasColumnName("contact_phone").IsRequired();


            builder.Property(p => p.ExpiresAt).HasColumnName("expires_at");
            builder.Property(p => p.CreatedAt)
                   .HasColumnName("created_at")
                   .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
            builder.Property(p => p.DeletedAt).HasColumnName("deleted_at");
        }
    }
}
