using HelioApp.Domain.Common;

namespace HelioApp.Domain.Entities.Community;

public class Poll : BaseEntity<Guid>
{
    public Guid PostId { get; set; }

    public string Question { get; set; } = default!;
    public bool AllowsMultipleChoices { get; set; } = false;
    public int TotalVotes { get; set; } = 0;
    public DateTimeOffset? EndsAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    // Navigation property
    public Post Post { get; set; } = default!;
}