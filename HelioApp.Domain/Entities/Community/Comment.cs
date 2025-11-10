using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.Community;

public sealed class Comment : BaseEntity<Guid>
{
    public Guid PostId { get; set; }
    public Post Post { get; set; } = null!;

    public string AuthorId { get; set; } = default!;
    public ApplicationUser Author { get; set; } = null!;

    public Guid? ParentCommentId { get; set; }
    public Comment? ParentComment { get; set; }

    public ICollection<Comment> Replies { get; set; } = new HashSet<Comment>();

    public string Content { get; set; } = default!;
    public List<string>? Images { get; set; } = new();

    public int LikesCount { get; set; } = 0;
    public int RepliesCount { get; set; } = 0;
    public int ReportsCount { get; set; } = 0;

    public CommentStatus Status { get; set; } = CommentStatus.Published;
}
