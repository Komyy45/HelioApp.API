using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Analytics_System
{
    public class ViewCount : BaseEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ViewableType { get; set; } = default!;
        public Guid ViewableId { get; set; }

        public string? UserId { get; set; } = default!;
        public ApplicationUser? User { get; set; }

        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }

        public DateTime ViewedAt { get; set; } = DateTime.UtcNow;
    }
}
