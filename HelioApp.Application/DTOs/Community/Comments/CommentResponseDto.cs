namespace HelioApp.Application.DTOs.Comments;

public class CommentResponse
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; } = default!;
    public string Content { get; set; } = default!;
    public List<string>? Images { get; set; }
    public int LikesCount { get; set; }
    public int RepliesCount { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public List<CommentResponse>? Replies { get; set; }
}
