using HelioApp.Domain.Entities.Marketplace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Marketplace
{
    public sealed class LostAndFoundItemConfigurations : IEntityTypeConfiguration<LostAndFoundItem>
    {
        public void Configure(EntityTypeBuilder<LostAndFoundItem> builder)
        {
            builder.ToTable("LostAndFoundItems");

            builder.HasKey(i => i.Id);

            builder.HasIndex(i => i.PosterId);
            builder.HasIndex(i => i.ItemType);
            builder.HasIndex(i => i.Status);
            builder.HasIndex(i => i.CreatedAt);

            builder.Property(i => i.Id).HasColumnName("id");

            builder.Property(i => i.PosterId)
                .HasColumnName("poster_id")
                .IsRequired();

            builder.Property(i => i.ItemType)
                .HasColumnName("item_type")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(i => i.Title)
                .HasColumnName("title")
                .IsRequired();

            builder.Property(i => i.Description)
                .HasColumnName("description")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(i => i.Category).HasColumnName("category");
            builder.Property(i => i.Location).HasColumnName("location").IsRequired();

            builder.Property(i => i.DateLostOrFound)
                .HasColumnName("date_lost_or_found")
                .IsRequired();

            builder.Property(i => i.Images)
                .HasColumnName("images")
                .HasColumnType("nvarchar(max)");

            builder.Property(i => i.ContactName).HasColumnName("contact_name");
            builder.Property(i => i.ContactPhone).HasColumnName("contact_phone");
            builder.Property(i => i.ContactEmail).HasColumnName("contact_email");

            builder.Property(i => i.Status)
                .HasColumnName("status")
                .HasConversion<string>();

            builder.Property(i => i.ViewCount)
                .HasColumnName("view_count")
                .HasDefaultValue(0);

            builder.Property(i => i.ExpiresAt).HasColumnName("expires_at");
            builder.Property(i => i.ResolvedAt).HasColumnName("resolved_at");

            builder.Property(i => i.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.Property(i => i.UpdatedAt).HasColumnName("updated_at");
            builder.Property(i => i.DeletedAt).HasColumnName("deleted_at");

            // Relationships
            builder.HasOne(i => i.Poster)
                .WithMany()
                .HasForeignKey(i => i.PosterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
