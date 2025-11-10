using HelioApp.Domain.Entities.Community;

namespace HelioApp.Application.Contracts.Repositories
{
    public interface ICommentRepository
    {
        Task AddAsync(Comment comment);
        Task SaveChangesAsync();
    }

}
