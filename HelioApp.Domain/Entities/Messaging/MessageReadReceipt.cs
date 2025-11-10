using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Messaging
{
    public class MessageReadReceipt : BaseEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid MessageId { get; set; }
        public Message Message { get; set; } = null!;

        public string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public DateTime ReadAt { get; set; } = DateTime.UtcNow;
    }
}
