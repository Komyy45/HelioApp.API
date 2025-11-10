using HelioApp.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.ContentManagement
{
    public sealed class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News");

            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id).HasColumnName("id");

            builder.Property(n => n.AuthorId).HasColumnName("author_id").IsRequired();

            builder.HasOne(n => n.Author)
                .WithMany()
                .HasForeignKey(n => n.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(n => n.Title).HasColumnName("title").IsRequired();
            builder.Property(n => n.Content).HasColumnName("content").IsRequired();
            builder.Property(n => n.Summary).HasColumnName("summary");

            builder.Property(n => n.FeaturedImageUrl).HasColumnName("featured_image_url").IsRequired();

            builder.Property(n => n.Images)
                   .HasColumnName("images")
                   .HasColumnType("nvarchar(max)");

            builder.Property(n => n.ExternalUrl).HasColumnName("external_url");
            builder.Property(n => n.Category).HasColumnName("category");

            builder.Property(n => n.IsFeatured).HasColumnName("is_featured").HasDefaultValue(false);
            builder.Property(n => n.IsPublished).HasColumnName("is_published").HasDefaultValue(true);

            builder.Property(n => n.ViewCount).HasColumnName("view_count").HasDefaultValue(0);

            builder.Property(n => n.PublishedAt).HasColumnName("published_at");
            builder.Property(n => n.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(n => n.UpdatedAt).HasColumnName("updated_at");
            builder.Property(n => n.DeletedAt).HasColumnName("deleted_at");
        }
    }
}
