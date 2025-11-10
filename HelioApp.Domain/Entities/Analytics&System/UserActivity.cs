using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Analytics_System
{
    public class UserActivity : BaseEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string UserId { get; set; } = default!;
        public ApplicationUser User { get; set; } = null!;

        public string ActivityType { get; set; } = default!;
        public string? RelatedType { get; set; }
        public Guid? RelatedId { get; set; }

        public string? Metadata { get; set; } // JSON

        public string? IpAddress { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
