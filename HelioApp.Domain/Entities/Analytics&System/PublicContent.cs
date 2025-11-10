using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Admin_Security;

namespace HelioApp.Domain.Entities.Analytics_System
{
    public class PublicContent : BaseEntity<Guid>
    {

        public string PageKey { get; set; } = default!; 
        public string Title { get; set; } = default!;
        public string? TitleAr { get; set; }
        public string Content { get; set; } = default!;
        public string? ContentAr { get; set; }
        public string? MetaDescription { get; set; }

        public bool IsPublished { get; set; } = true;

        public string? LastUpdatedBy { get; set; }
        //public AdminUser? LastUpdatedByAdmin { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
