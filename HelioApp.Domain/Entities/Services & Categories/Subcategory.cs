using HelioApp.Domain.Common;

namespace HelioApp.Domain.Entities.Services___Categories
{
    public sealed class Subcategory : BaseEntity<Guid>
    {
        public Guid CategoryId { get; set; }

        public Category Category { get; set; } = default!;

        public string Name { get; set; } = default!;
        public string? NameAr { get; set; }
        public string? Description { get; set; }

        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
