using HelioApp.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.ContentManagement
{
    public sealed class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offers");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).HasColumnName("id");

            builder.Property(o => o.ServiceId).HasColumnName("service_id");
            builder.HasOne(o => o.Service)
                   .WithMany()
                   .HasForeignKey(o => o.ServiceId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.Property(o => o.CreatedById).HasColumnName("created_by_id").IsRequired();

            builder.HasOne(o => o.CreatedBy)
                   .WithMany()
                   .HasForeignKey(o => o.CreatedById)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.Title).HasColumnName("title").IsRequired();
            builder.Property(o => o.Description).HasColumnName("description").IsRequired();
            builder.Property(o => o.TermsAndConditions).HasColumnName("terms_and_conditions");
            builder.Property(o => o.PictureUrl).HasColumnName("picture_url").IsRequired();

            builder.Property(o => o.OfferType)
                   .HasColumnName("offer_type")
                   .HasConversion<byte>();

            builder.Property(o => o.DiscountPercentage).HasColumnName("discount_percentage");
            builder.Property(o => o.DiscountAmount).HasColumnName("discount_amount");

            builder.Property(o => o.RedemptionMethod)
                   .HasColumnName("redemption_method")
                   .HasConversion<byte>();

            builder.Property(o => o.MaxRedemptions).HasColumnName("max_redemptions");
            builder.Property(o => o.CurrentRedemptions).HasColumnName("current_redemptions").HasDefaultValue(0);
            builder.Property(o => o.RequiresCode).HasColumnName("requires_code").HasDefaultValue(false);

            builder.Property(o => o.Status)
                   .HasColumnName("status")
                   .HasConversion<byte>();

            builder.Property(o => o.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(o => o.EndDate).HasColumnName("end_date").IsRequired();

            builder.Property(o => o.ViewCount).HasColumnName("view_count").HasDefaultValue(0);
            builder.Property(o => o.ClaimCount).HasColumnName("claim_count").HasDefaultValue(0);

            builder.Property(o => o.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(o => o.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
