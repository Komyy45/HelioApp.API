using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Admin_Security
{
    public class ReportedContent : BaseEntity<Guid>
    {

        public string ReporterId { get; set; }
        public ApplicationUser Reporter { get; set; } = null!;

        public string ContentType { get; set; } = default!;
        public Guid ContentId { get; set; }

        public string Reason { get; set; } = default!; // spam | harassment | inappropriate | false_info | other
        public string? Description { get; set; }

        public string Status { get; set; } = "pending"; // pending | reviewing | dismissed | action_taken

        public string? ReviewedBy { get; set; }
        //public AdminUser? ReviewedByAdmin { get; set; }

        public DateTime? ReviewedAt { get; set; }
        public string? ActionTaken { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
