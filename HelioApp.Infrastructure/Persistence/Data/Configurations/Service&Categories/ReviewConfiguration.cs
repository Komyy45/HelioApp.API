using HelioApp.Domain.Entities.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Service_Categories
{
    public sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Author)
                   .WithMany()
                   .HasForeignKey(r => r.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Service)
                   .WithMany(s => s.Reviews)
                   .HasForeignKey(r => r.ServiceId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.Rating).IsRequired();

            builder.Property(r => r.Title);
            builder.Property(r => r.Body).IsRequired();

            builder.Property(r => r.Images)
                .HasColumnType("nvarchar(max)");

            builder.Property(r => r.IsVerifiedPurchase).HasDefaultValue(false);
            builder.Property(r => r.HelpfulCount).HasDefaultValue(0);

            builder.Property(r => r.Status)
                .HasConversion<byte>();

            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(r => r.UpdatedAt);
            builder.Property(r => r.DeletedAt);
        }
    }
}
