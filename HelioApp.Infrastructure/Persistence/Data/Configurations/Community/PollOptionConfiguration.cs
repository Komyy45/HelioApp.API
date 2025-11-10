using HelioApp.Domain.Entities.Community;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Community
{
    public sealed class PollOptionConfiguration : IEntityTypeConfiguration<PollOption>
    {
        public void Configure(EntityTypeBuilder<PollOption> builder)
        {
            builder.ToTable("PollOptions");

            builder.HasKey(po => po.Id);

            builder.Property(po => po.Id).HasColumnName("id");

            builder.Property(po => po.PollId).HasColumnName("poll_id").IsRequired();
            builder.HasOne(po => po.Poll)
                .WithMany()
                .HasForeignKey(po => po.PollId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(po => po.OptionText).HasColumnName("option_text").IsRequired();

            builder.Property(po => po.DisplayOrder).HasColumnName("display_order").HasDefaultValue(0);

            builder.Property(po => po.VotesCount).HasColumnName("votes_count").HasDefaultValue(0);

            builder.Property(po => po.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
