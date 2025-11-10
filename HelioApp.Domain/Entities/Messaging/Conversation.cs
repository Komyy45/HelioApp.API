using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Messaging
{
    public class Conversation : BaseEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ConversationType { get; set; } = "direct"; // direct | group
        public string? Title { get; set; }

        public string? LastMessageContent { get; set; }
        public DateTime? LastMessageAt { get; set; }
        public string? LastMessageBy { get; set; }
        public ApplicationUser? LastMessageUser { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ConversationParticipant> Participants { get; set; } = new HashSet<ConversationParticipant>();
        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
    }
}
