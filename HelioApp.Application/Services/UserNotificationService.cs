using AutoMapper;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;
using HelioApp.Domain.Exceptions; 

namespace HelioApp.Application.Services
{
    internal sealed class UserNotificationService(
        IUserNotificationRepository userNotificationRepository,
        IMapper mapper
    ) : IUserNotificationService
    {
        public async Task<IEnumerable<UserBriefNotificationDto>> GetNotificationsForUserAsync(string userId)
        {
            var userNotifications = await userNotificationRepository.GetUserNotificationsAsync(userId);
            return mapper.Map<IEnumerable<UserBriefNotificationDto>>(userNotifications);
        }


        public async Task<int> GetUnreadCountAsync(string userId)
        {
            var userNotifications = await userNotificationRepository.GetUserNotificationsAsync(userId);
            return userNotifications.Count(un => !un.IsRead);
        }

        public async Task MarkAsReadAsync(Guid userNotificationId, string userId)
        {
            var userNotification = await userNotificationRepository.GetByIdAsync(userNotificationId);
            if (userNotification is null)
            {
                throw new NotFoundException("User Notification");
            }

            if (userNotification.UserId != userId)
            {
                throw new ApplicationException("Access denied. Notification does not belong to user.");
            }

            if (!userNotification.IsRead)
            {
                userNotification.IsRead = true;
                userNotification.ReadAt = DateTimeOffset.UtcNow;

                userNotificationRepository.Update(userNotification);
                await userNotificationRepository.CompleteAsync();
            }
        }

        public async Task DeleteForUserAsync(Guid userNotificationId, string userId)
        {
            var userNotification = await userNotificationRepository.GetByIdAsync(userNotificationId);

            if (userNotification is null)
            {
                throw new NotFoundException("User Notification");
            }

            if (userNotification.UserId != userId)
            {
                throw new ApplicationException("Access denied. Notification does not belong to user.");
            }

            userNotificationRepository.Delete(userNotification);
            await userNotificationRepository.CompleteAsync();
        }
    }
}