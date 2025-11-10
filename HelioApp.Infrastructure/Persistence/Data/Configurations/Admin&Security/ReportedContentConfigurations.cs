using HelioApp.Domain.Entities.Admin_Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Admin_Security
{
    public sealed class ReportedContentConfigurations : IEntityTypeConfiguration<ReportedContent>
    {
        public void Configure(EntityTypeBuilder<ReportedContent> builder)
        {
            builder.ToTable("ReportedContent");

            builder.HasKey(rc => rc.Id);

            builder.HasIndex(rc => rc.ReporterId);
            builder.HasIndex(rc => rc.ContentType);
            builder.HasIndex(rc => rc.ContentId);
            builder.HasIndex(rc => rc.Status);
            builder.HasIndex(rc => rc.CreatedAt);

            builder.Property(rc => rc.Id)
                .HasColumnName("id");

            builder.Property(rc => rc.ReporterId)
                .HasColumnName("reporter_id")
                .IsRequired();

            builder.Property(rc => rc.ContentType)
                .HasColumnName("content_type")
                .IsRequired();

            builder.Property(rc => rc.ContentId)
                .HasColumnName("content_id")
                .IsRequired();

            builder.Property(rc => rc.Reason)
                .HasColumnName("reason")
                .HasConversion<string>() 
                .IsRequired();

            builder.Property(rc => rc.Description)
                .HasColumnName("description")
                .HasColumnType("nvarchar(max)");

            builder.Property(rc => rc.Status)
                .HasColumnName("status")
                .HasConversion<string>() 
                .HasDefaultValue("pending");

            builder.Property(rc => rc.ReviewedBy)
                .HasColumnName("reviewed_by");

            builder.Property(rc => rc.ReviewedAt)
                .HasColumnName("reviewed_at");

            builder.Property(rc => rc.ActionTaken)
                .HasColumnName("action_taken")
                .HasColumnType("nvarchar(max)");

            builder.Property(rc => rc.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.Property(rc => rc.UpdatedAt)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            // Relationships
            builder.HasOne(rc => rc.Reporter)
                .WithMany() 
                .HasForeignKey(rc => rc.ReporterId)
                .OnDelete(DeleteBehavior.Cascade);

            // builder.HasOne(rc => rc.ReviewedByAdmin)
            //     .WithMany()
            //     .HasForeignKey(rc => rc.ReviewedBy)
            //     .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
