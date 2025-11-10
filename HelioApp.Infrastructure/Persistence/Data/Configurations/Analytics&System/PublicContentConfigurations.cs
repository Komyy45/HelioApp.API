using HelioApp.Domain.Entities.Analytics_System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Analytics_System
{
    public sealed class PublicContentConfigurations : IEntityTypeConfiguration<PublicContent>
    {
        public void Configure(EntityTypeBuilder<PublicContent> builder)
        {
            builder.ToTable("PublicContent");

            builder.HasKey(pc => pc.Id);

            builder.HasIndex(pc => pc.PageKey).IsUnique();
            builder.HasIndex(pc => pc.IsPublished);

            builder.Property(pc => pc.Id)
                .HasColumnName("id");

            builder.Property(pc => pc.PageKey)
                .HasColumnName("page_key")
                .IsRequired();

            builder.Property(pc => pc.Title)
                .HasColumnName("title")
                .IsRequired();

            builder.Property(pc => pc.TitleAr)
                .HasColumnName("title_ar");

            builder.Property(pc => pc.Content)
                .HasColumnName("content")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(pc => pc.ContentAr)
                .HasColumnName("content_ar")
                .HasColumnType("nvarchar(max)");

            builder.Property(pc => pc.MetaDescription)
                .HasColumnName("meta_description")
                .HasColumnType("nvarchar(max)");

            builder.Property(pc => pc.IsPublished)
                .HasColumnName("is_published")
                .HasDefaultValue(true);

            builder.Property(pc => pc.LastUpdatedBy)
                .HasColumnName("last_updated_by");

            builder.Property(pc => pc.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.Property(pc => pc.UpdatedAt)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            // Relationships
            // builder.HasOne(pc => pc.LastUpdatedByAdmin)
            //     .WithMany()
            //     .HasForeignKey(pc => pc.LastUpdatedBy)
            //     .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
