using HelioApp.Domain.Entities.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Messaging
{
    public sealed class MessageConfigurations : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(m => m.Id);

            builder.HasIndex(m => m.ConversationId);
            builder.HasIndex(m => m.SenderId);
            builder.HasIndex(m => m.CreatedAt);

            builder.Property(m => m.Id).HasColumnName("id");

            builder.Property(m => m.ConversationId).HasColumnName("conversation_id").IsRequired();
            builder.Property(m => m.SenderId).HasColumnName("sender_id").IsRequired();

            builder.Property(m => m.Content)
                .HasColumnName("content")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(m => m.MessageType)
                .HasColumnName("message_type")
                .HasDefaultValue("text");

            builder.Property(m => m.MediaUrl).HasColumnName("media_url");
            builder.Property(m => m.FileName).HasColumnName("file_name");
            builder.Property(m => m.FileSize).HasColumnName("file_size");

            builder.Property(m => m.IsEdited)
                .HasColumnName("is_edited")
                .HasDefaultValue(false);

            builder.Property(m => m.EditedAt)
                .HasColumnName("edited_at");

            builder.Property(m => m.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false);

            builder.Property(m => m.DeletedAt)
                .HasColumnName("deleted_at");

            builder.Property(m => m.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            // Relationships
            builder.HasOne(m => m.Conversation)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
