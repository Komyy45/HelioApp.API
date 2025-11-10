using HelioApp.Domain.Entities.Community;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Community
{
    public sealed class PollVoteConfiguration : IEntityTypeConfiguration<PollVote>
    {
        public void Configure(EntityTypeBuilder<PollVote> builder)
        {
            builder.ToTable("PollVotes");

            builder.HasKey(pv => pv.Id);

            builder.Property(pv => pv.Id).HasColumnName("id");

            builder.Property(pv => pv.PollId).HasColumnName("poll_id").IsRequired();
            builder.HasOne(pv => pv.Poll)
                .WithMany()
                .HasForeignKey(pv => pv.PollId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(pv => pv.OptionId).HasColumnName("option_id").IsRequired();
            builder.HasOne(pv => pv.Option)
                .WithMany()
                .HasForeignKey(pv => pv.OptionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(pv => pv.UserId).HasColumnName("user_id").IsRequired();
            builder.HasOne(pv => pv.User)
                .WithMany()
                .HasForeignKey(pv => pv.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(pv => pv.VotedAt).HasColumnName("voted_at").HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
