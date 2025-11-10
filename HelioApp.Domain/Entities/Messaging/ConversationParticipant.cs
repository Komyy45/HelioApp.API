using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Messaging
{
    public class ConversationParticipant : BaseEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; } = null!;

        public string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public string Role { get; set; } = "member"; // member | admin
        public int UnreadCount { get; set; } = 0;

        public DateTime? LastReadAt { get; set; }
        public bool IsMuted { get; set; } = false;

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LeftAt { get; set; }
    }
}
