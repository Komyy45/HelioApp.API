using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.Marketplace;

public class Job : BaseEntity<Guid>
{
    public string PosterId { get; set; }

    public string Title { get; set; } = default!;
    public string? CompanyName { get; set; }
    public string Description { get; set; } = default!;

    public JobType JobType { get; set; }
    public string? Category { get; set; }
    public string Location { get; set; } = default!;

    public decimal? SalaryMin { get; set; }
    public decimal? SalaryMax { get; set; }
    public string SalaryCurrency { get; set; } = "EGP";
    public SalaryPeriod? SalaryPeriod { get; set; }

    public string? ExperienceRequired { get; set; }
    public string? Requirements { get; set; }

    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }

    public JobStatus Status { get; set; } = JobStatus.Pending;
    public int ApplicationsCount { get; set; } = 0;
    public int ViewCount { get; set; } = 0;

    public DateTimeOffset? ExpiresAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    // Navigation
    public ApplicationUser Poster { get; set; } = default!;
}