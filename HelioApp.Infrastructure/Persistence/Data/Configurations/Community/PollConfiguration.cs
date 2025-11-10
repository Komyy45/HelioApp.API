using HelioApp.Domain.Entities.Community;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Community
{
    public sealed class PollConfiguration : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.ToTable("Polls");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.PostId).HasColumnName("post_id").IsRequired();
            builder.HasOne(p => p.Post)
                .WithMany()
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Question).HasColumnName("question").IsRequired();

            builder.Property(p => p.AllowsMultipleChoices).HasColumnName("allows_multiple_choices").HasDefaultValue(false);

            builder.Property(p => p.TotalVotes).HasColumnName("total_votes").HasDefaultValue(0);

            builder.Property(p => p.EndsAt).HasColumnName("ends_at");

            builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
