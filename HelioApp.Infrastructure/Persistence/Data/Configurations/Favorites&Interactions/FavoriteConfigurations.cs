using HelioApp.Domain.Entities.Favorites_Interactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Favorites_Interactions
{
    public sealed class FavoriteConfigurations : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorites");

            builder.HasKey(f => f.Id);

            builder.HasIndex(f => f.UserId);
            builder.HasIndex(f => new { f.FavoritableType, f.FavoritableId });
            builder.HasIndex(f => new { f.UserId, f.FavoritableType, f.FavoritableId })
                   .IsUnique();

            builder.Property(f => f.Id)
                .HasColumnName("id");

            builder.Property(f => f.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(f => f.FavoritableType)
                .HasColumnName("favoritable_type")
                .IsRequired();

            builder.Property(f => f.FavoritableId)
                .HasColumnName("favoritable_id")
                .IsRequired();

            builder.Property(f => f.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            // Relationships
            builder.HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
