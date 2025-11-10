using HelioApp.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.ContentManagement
{
    public sealed class OfferClaimConfiguration : IEntityTypeConfiguration<OfferClaim>
    {
        public void Configure(EntityTypeBuilder<OfferClaim> builder)
        {
            builder.ToTable("OfferClaims");

            builder.HasKey(oc => oc.Id);

            builder.Property(oc => oc.Id).HasColumnName("id");

            builder.Property(oc => oc.OfferId).HasColumnName("offer_id").IsRequired();
            builder.HasOne(oc => oc.Offer)
                   .WithMany()
                   .HasForeignKey(oc => oc.OfferId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(oc => oc.UserId).HasColumnName("user_id").IsRequired();
            builder.HasOne(oc => oc.User)
                   .WithMany()
                   .HasForeignKey(oc => oc.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(oc => oc.ClaimCode).HasColumnName("claim_code").IsRequired();
            builder.Property(oc => oc.IsRedeemed).HasColumnName("is_redeemed").HasDefaultValue(false);
            builder.Property(oc => oc.RedeemedAt).HasColumnName("redeemed_at");
            builder.Property(oc => oc.RedemptionLocation).HasColumnName("redemption_location");

            builder.Property(oc => oc.ExpiresAt).HasColumnName("expires_at").IsRequired();
            builder.Property(oc => oc.ClaimedAt).HasColumnName("claimed_at").HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
