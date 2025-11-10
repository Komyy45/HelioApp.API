using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Messaging
{
    public class Message : BaseEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; } = null!;

        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; } = null!;

        public string Content { get; set; } = default!;
        public string MessageType { get; set; } = "text"; // text | image | file | location

        public string? MediaUrl { get; set; }
        public string? FileName { get; set; }
        public int? FileSize { get; set; }

        public bool IsEdited { get; set; } = false;
        public DateTime? EditedAt { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<MessageReadReceipt> ReadReceipts { get; set; } = new HashSet<MessageReadReceipt>();
    }
}
