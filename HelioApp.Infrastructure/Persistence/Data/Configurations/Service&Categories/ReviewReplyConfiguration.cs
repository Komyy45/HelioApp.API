using HelioApp.Domain.Entities.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Service_Categories
{
    public sealed class ReviewReplyConfiguration : IEntityTypeConfiguration<ReviewReply>
    {
        public void Configure(EntityTypeBuilder<ReviewReply> builder)
        {
            builder.ToTable("ReviewReplies");

            builder.HasKey(rr => rr.Id);

            builder.HasOne(rr => rr.Review)
                   .WithOne(r => r.Reply)
                   .HasForeignKey<ReviewReply>(rr => rr.ReviewId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rr => rr.Author)
                   .WithMany()
                   .HasForeignKey(rr => rr.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(rr => rr.AuthorType)
                .HasConversion<byte>();

            builder.Property(rr => rr.Content).IsRequired();

            builder.Property(rr => rr.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(rr => rr.UpdatedAt);
        }
    }
}
