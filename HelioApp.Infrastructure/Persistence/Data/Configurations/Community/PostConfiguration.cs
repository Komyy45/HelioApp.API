using HelioApp.Domain.Entities.Community;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Community
{
    public sealed class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.AuthorId).HasColumnName("author_id").IsRequired();
            builder.HasOne(p => p.Author)
                .WithMany()
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.CircleId).HasColumnName("circle_id");
            builder.HasOne(p => p.Circle)
                .WithMany()
                .HasForeignKey(p => p.CircleId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(p => p.Title).HasColumnName("title");
            builder.Property(p => p.Content).HasColumnName("content").IsRequired();

            builder.Property(p => p.PostType)
                .HasColumnName("post_type")
                .HasConversion<byte>();

            builder.Property(p => p.Images)
                   .HasColumnName("images")
                   .HasColumnType("nvarchar(max)")
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                       v => JsonSerializer.Deserialize<string>(v, (JsonSerializerOptions?)null));

            builder.Property(p => p.IsPinned).HasColumnName("is_pinned").HasDefaultValue(false);
            builder.Property(p => p.IsLocked).HasColumnName("is_locked").HasDefaultValue(false);

            builder.Property(p => p.Status)
                .HasColumnName("status")
                .HasConversion<byte>();

            builder.Property(p => p.LikesCount).HasColumnName("likes_count").HasDefaultValue(0);
            builder.Property(p => p.CommentsCount).HasColumnName("comments_count").HasDefaultValue(0);
            builder.Property(p => p.ViewCount).HasColumnName("view_count").HasDefaultValue(0);
            builder.Property(p => p.ReportsCount).HasColumnName("reports_count").HasDefaultValue(0);

            builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
            builder.Property(p => p.DeletedAt).HasColumnName("deleted_at");
        }
    }
}
