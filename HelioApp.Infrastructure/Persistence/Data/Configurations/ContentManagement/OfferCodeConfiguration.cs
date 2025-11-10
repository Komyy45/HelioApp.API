using HelioApp.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.ContentManagement
{
    public sealed class OfferCodeConfiguration : IEntityTypeConfiguration<OfferCode>
    {
        public void Configure(EntityTypeBuilder<OfferCode> builder)
        {
            builder.ToTable("OfferCodes");

            builder.HasKey(oc => oc.Id);

            builder.Property(oc => oc.Id).HasColumnName("id");

            builder.Property(oc => oc.OfferId).HasColumnName("offer_id").IsRequired();
            builder.HasOne(oc => oc.Offer)
                   .WithMany()
                   .HasForeignKey(oc => oc.OfferId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(oc => oc.Code).HasColumnName("code").IsRequired();
            builder.Property(oc => oc.IsUsed).HasColumnName("is_used").HasDefaultValue(false);

            builder.Property(oc => oc.UsedBy).HasColumnName("used_by");
            builder.HasOne(oc => oc.User)
                   .WithMany()
                   .HasForeignKey(oc => oc.UsedBy)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.Property(oc => oc.UsedAt).HasColumnName("used_at");
            builder.Property(oc => oc.ExpiresAt).HasColumnName("expires_at").IsRequired();
            builder.Property(oc => oc.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
