using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Entities.Reviews;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.Services___Categories
{
    public sealed class Service : BaseEntity<Guid>
    {

        // Foreign Keys
        public string ProviderId { get; set; } = default!;
        public Guid SubcategoryId { get; set; }

        // Navigation Properties
        public ApplicationUser Provider { get; set; } = default!;
        public Subcategory? Subcategory { get; set; }

        // Core Info
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Address { get; set; } = default!;

        // Location
        public decimal? LocationLat { get; set; }
        public decimal? LocationLng { get; set; }

        // Contact
        public string Phone { get; set; } = default!;
        public string? Whatsapp { get; set; }
        public string? Email { get; set; }
        public string? WebsiteUrl { get; set; }

        public string? CoverImageUrl { get; set; }

        // JSON fields
        public List<string>? Images { get; set; }
        public string? WorkingHours { get; set; } 

        public bool IsVerified { get; set; } = false;
        public ServiceStatus Status { get; set; } = ServiceStatus.Pending;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; } 

        public ICollection<Review>? Reviews { get; set; }
    }
}
