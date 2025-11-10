using HelioApp.Domain.Entities.Favorites_Interactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Favorites_Interactions
{
    public sealed class UserRelationshipConfigurations : IEntityTypeConfiguration<UserRelationship>
    {
        public void Configure(EntityTypeBuilder<UserRelationship> builder)
        {
            builder.ToTable("UserRelationships");

            builder.HasKey(r => r.Id);

            builder.HasIndex(r => new { r.UserId, r.RelatedUserId, r.RelationshipType })
                   .IsUnique();

            builder.HasIndex(r => r.UserId);
            builder.HasIndex(r => r.RelatedUserId);
            builder.HasIndex(r => r.RelationshipType);

            builder.Property(r => r.Id)
                .HasColumnName("id");

            builder.Property(r => r.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(r => r.RelatedUserId)
                .HasColumnName("related_user_id")
                .IsRequired();

            builder.Property(r => r.RelationshipType)
                .HasColumnName("relationship_type")
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            // Relationships
            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.RelatedUser)
                .WithMany()
                .HasForeignKey(r => r.RelatedUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
