using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.Contracts.Repositories
{
    public interface IUserNotificationRepository : IGenericRepository<UserNotification, Guid>
    {
        Task<IEnumerable<UserNotification>> GetUserNotificationsAsync(string userId);
        Task<UserNotification?> GetByUserAndNotificationIdAsync(string userId, Guid notificationId);
        Task MarkAsReadAsync(Guid userNotificationId, DateTimeOffset readAt);
    }
}