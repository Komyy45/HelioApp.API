using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Favorites_Interactions
{
    public class UserRelationship : BaseEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public string RelatedUserId { get; set; }
        public ApplicationUser RelatedUser { get; set; } = null!;

        public string RelationshipType { get; set; } = default!; // follow | friend | block

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
