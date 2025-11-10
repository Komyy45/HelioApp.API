using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.Marketplace;

public class JobApplication : BaseEntity<Guid>
{
    // Foreign Keys
    public Guid JobId { get; set; }
    public string ApplicantId { get; set; }

    // Navigation Properties
    public Job Job { get; set; } = null!;
    public ApplicationUser Applicant { get; set; } = null!;

    // Fields
    public string? CoverLetter { get; set; }
    public string? ResumeUrl { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }

    public JobApplicationStatus Status { get; set; } = JobApplicationStatus.Pending;

    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}