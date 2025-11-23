using HelioApp.Application.DTOs.ContentManagement;

namespace HelioApp.Application.Contracts.Services
{
    public interface IUserNotificationService
    {
        Task<IEnumerable<UserBriefNotificationDto>> GetNotificationsForUserAsync(string userId);
        Task<int> GetUnreadCountAsync(string userId);
        Task MarkAsReadAsync(Guid userNotificationId, string userId);
        Task DeleteForUserAsync(Guid userNotificationId, string userId);
    }
}