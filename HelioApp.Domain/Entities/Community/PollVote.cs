using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Community;

public class PollVote : BaseEntity<Guid>
{
    public Guid PollId { get; set; }
    public Guid OptionId { get; set; }
    public string UserId { get; set; } = default!;

    public DateTimeOffset VotedAt { get; set; } = DateTimeOffset.UtcNow;

    // Navigation properties
    public Poll Poll { get; set; } = default!;
    public PollOption Option { get; set; } = default!;
    public ApplicationUser User { get; set; } = default!;
}