using HelioApp.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.ContentManagement
{
    public sealed class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.ToTable("Ads");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("id");

            builder.Property(a => a.CreatedBy).HasColumnName("created_by").IsRequired();

            builder.HasOne(a => a.CreatedByUser)
                   .WithMany()
                   .HasForeignKey(a => a.CreatedBy)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(a => a.Title).HasColumnName("title").IsRequired();
            builder.Property(a => a.Content).HasColumnName("content");
            builder.Property(a => a.PictureUrl).HasColumnName("picture_url").IsRequired();
            builder.Property(a => a.VideoUrl).HasColumnName("video_url");

            builder.Property(a => a.Placement)
                   .HasColumnName("placement")
                   .HasConversion<byte>()
                   .IsRequired();

            builder.Property(a => a.ReferralType)
                   .HasColumnName("referral_type")
                   .HasConversion<byte>()
                   .IsRequired();

            builder.Property(a => a.ReferralId).HasColumnName("referral_id");
            builder.Property(a => a.ExternalUrl).HasColumnName("external_url");

            builder.Property(a => a.TargetAudience)
                   .HasColumnName("target_audience")
                   .HasConversion<byte>();

            builder.Property(a => a.ImpressionCount).HasColumnName("impression_count").HasDefaultValue(0);
            builder.Property(a => a.ClickCount).HasColumnName("click_count").HasDefaultValue(0);

            builder.Property(a => a.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(a => a.EndDate).HasColumnName("end_date").IsRequired();

            builder.Property(a => a.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(a => a.Priority).HasColumnName("priority").HasDefaultValue(0);
            builder.Property(a => a.Budget).HasColumnName("budget");

            builder.Property(a => a.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(a => a.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
