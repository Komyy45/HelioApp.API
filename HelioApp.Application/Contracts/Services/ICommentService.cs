using HelioApp.Application.DTOs.Comments;

namespace HelioApp.Application.Contracts.Services
{
    public interface ICommentService
    {
        Task<CommentResponse> CreateCommentAsync(Guid authorId, CreateCommentRequest request);
        Task<IEnumerable<CommentResponse>> GetCommentsByPostAsync(Guid postId);
        Task<CommentResponse?> GetCommentByIdAsync(Guid id);
        Task<bool> DeleteCommentAsync(Guid id, Guid authorId);
        Task<bool> LikeCommentAsync(Guid id);
        Task<bool> ReportCommentAsync(Guid id);
    }
}
