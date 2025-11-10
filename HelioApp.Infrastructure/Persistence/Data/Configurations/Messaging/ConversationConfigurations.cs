using HelioApp.Domain.Entities.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Messaging
{
    public sealed class ConversationConfigurations : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.ToTable("Conversations");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.ConversationType);
            builder.HasIndex(c => c.LastMessageAt);
            builder.HasIndex(c => c.IsActive);

            builder.Property(c => c.Id).HasColumnName("id");

            builder.Property(c => c.ConversationType)
                .HasColumnName("conversation_type")
                .IsRequired()
                .HasDefaultValue("direct");

            builder.Property(c => c.Title)
                .HasColumnName("title");

            builder.Property(c => c.LastMessageContent)
                .HasColumnName("last_message_content")
                .HasColumnType("nvarchar(max)");

            builder.Property(c => c.LastMessageAt)
                .HasColumnName("last_message_at");

            builder.Property(c => c.LastMessageBy)
                .HasColumnName("last_message_by");

            builder.Property(c => c.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true);

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at");

            // Relationships
            builder.HasOne(c => c.LastMessageUser)
                .WithMany()
                .HasForeignKey(c => c.LastMessageBy)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.Participants)
                .WithOne(p => p.Conversation)
                .HasForeignKey(p => p.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Messages)
                .WithOne(m => m.Conversation)
                .HasForeignKey(m => m.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
