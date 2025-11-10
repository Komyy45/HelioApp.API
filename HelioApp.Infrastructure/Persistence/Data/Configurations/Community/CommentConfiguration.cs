using HelioApp.Domain.Entities.Community;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Community
{
    public sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("id");

            builder.Property(c => c.PostId).HasColumnName("post_id").IsRequired();
            builder.HasOne(c => c.Post)
                .WithMany()
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.AuthorId).HasColumnName("author_id").IsRequired();
            builder.HasOne(c => c.Author)
                .WithMany()
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(c => c.ParentCommentId).HasColumnName("parent_comment_id");
            builder.HasOne(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.Content).HasColumnName("content").IsRequired();

            builder.Property(c => c.Images)
                   .HasColumnName("images")
                   .HasColumnType("nvarchar(max)");

            builder.Property(c => c.LikesCount).HasColumnName("likes_count").HasDefaultValue(0);
            builder.Property(c => c.RepliesCount).HasColumnName("replies_count").HasDefaultValue(0);
            builder.Property(c => c.ReportsCount).HasColumnName("reports_count").HasDefaultValue(0);

            builder.Property(c => c.Status)
                .HasColumnName("status")
                .HasConversion<byte>();
        }
    }
}
