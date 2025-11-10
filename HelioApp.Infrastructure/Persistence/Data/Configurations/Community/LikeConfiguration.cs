using HelioApp.Domain.Entities.Community;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Community
{
    public sealed class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Likes");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id).HasColumnName("id");

            builder.Property(l => l.UserId).HasColumnName("user_id").IsRequired();
            builder.HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(l => l.LikeableType).HasColumnName("likeable_type").IsRequired();
            builder.Property(l => l.LikeableId).HasColumnName("likeable_id").IsRequired();

            builder.Property(l => l.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
