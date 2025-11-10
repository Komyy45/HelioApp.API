using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Favorites_Interactions
{
    public class Favorite : BaseEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        // Polymorphic Reference: Service | Property | Post
        public string FavoritableType { get; set; } = default!;
        public Guid FavoritableId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
