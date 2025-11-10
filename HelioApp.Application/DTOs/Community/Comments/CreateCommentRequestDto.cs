namespace HelioApp.Application.DTOs.Comments;

public class CreateCommentRequest
{
    public Guid PostId { get; set; }
    public Guid? ParentCommentId { get; set; }
    public string Content { get; set; } = default!;
    public List<string>? Images { get; set; } = new();
}
