using HelioApp.Domain.Entities.Marketplace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Marketplace
{
    public sealed class MarketplaceItemConfigurations : IEntityTypeConfiguration<MarketplaceItem>
    {
        public void Configure(EntityTypeBuilder<MarketplaceItem> builder)
        {
            builder.ToTable("MarketplaceItems");

            builder.HasKey(m => m.Id);

            builder.HasIndex(m => m.SellerId);
            builder.HasIndex(m => m.Status);
            builder.HasIndex(m => m.Category);
            builder.HasIndex(m => m.CreatedAt);

            builder.Property(m => m.Id).HasColumnName("id");

            builder.Property(m => m.SellerId)
                .HasColumnName("seller_id")
                .IsRequired();

            builder.Property(m => m.Title)
                .HasColumnName("title")
                .IsRequired();

            builder.Property(m => m.Description)
                .HasColumnName("description")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(m => m.Price)
                .HasColumnName("price")
                .HasPrecision(15, 2)
                .IsRequired();

            builder.Property(m => m.Currency)
                .HasColumnName("currency")
                .HasDefaultValue("EGP");

            builder.Property(m => m.Category).HasColumnName("category");

            builder.Property(m => m.Condition)
                .HasColumnName("condition")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(m => m.Location).HasColumnName("location").IsRequired();

            builder.Property(m => m.Images)
                .HasColumnName("images")
                .HasColumnType("nvarchar(max)");

            builder.Property(m => m.ContactMethod)
                .HasColumnName("contact_method")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(m => m.Status)
                .HasColumnName("status")
                .HasConversion<string>();

            builder.Property(m => m.ViewCount)
                .HasColumnName("view_count")
                .HasDefaultValue(0);

            builder.Property(m => m.IsNegotiable)
                .HasColumnName("is_negotiable")
                .HasDefaultValue(true);

            builder.Property(m => m.ExpiresAt).HasColumnName("expires_at");
            builder.Property(m => m.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(m => m.UpdatedAt).HasColumnName("updated_at");
            builder.Property(m => m.DeletedAt).HasColumnName("deleted_at");

            // Relationships
            builder.HasOne(m => m.Seller)
                .WithMany()
                .HasForeignKey(m => m.SellerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
