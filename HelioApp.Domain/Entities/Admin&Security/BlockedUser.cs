using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Admin_Security
{
    public class BlockedUser : BaseEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string BlockerId { get; set; } = default!;
        public ApplicationUser Blocker { get; set; } = null!;

        public string BlockedId { get; set; } = default!;
        public ApplicationUser Blocked { get; set; } = null!;

        public string? Reason { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
