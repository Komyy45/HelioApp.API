using HelioApp.Domain.Common;

namespace HelioApp.Domain.Entities.Community;

public sealed class PollOption : BaseEntity<Guid>
{
    public Guid PollId { get; set; }

    public string OptionText { get; set; } = default!;
    public int DisplayOrder { get; set; } = 0;
    public int VotesCount { get; set; } = 0;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    // Navigation property
    public Poll Poll { get; set; } = default!;
}