using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Infrastructure.Persistence.Data;
using HelioApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Repositories
{
    public class UserNotificationRepository : GenericRepository<UserNotification, Guid>, IUserNotificationRepository
    {
        private readonly HelioAppDbContext _dbContext;
        public UserNotificationRepository(HelioAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UserNotification>> GetUserNotificationsAsync(string userId)
        {
            return await _dbContext.Set<UserNotification>()
                .Where(un => un.UserId == userId)
                .Include(un => un.Notification)
                .OrderByDescending(un => un.CreatedAt)
                .ToListAsync();
        }

        public async Task<UserNotification?> GetByUserAndNotificationIdAsync(string userId, Guid notificationId)
        {
            return await _dbContext.Set<UserNotification>()
                .Include(un => un.Notification)
                .FirstOrDefaultAsync(un => un.UserId == userId && un.NotificationId == notificationId);
        }

        public async Task MarkAsReadAsync(Guid userNotificationId, DateTimeOffset readAt)
        {
            var userNotification = await _dbContext.Set<UserNotification>()
                .FirstOrDefaultAsync(un => un.Id == userNotificationId);

            if (userNotification is not null)
            {
                if (!userNotification.IsRead)
                {
                    userNotification.IsRead = true;
                    userNotification.ReadAt = readAt;
                }
            }
            else
            {
                throw new Exception("User Notification entry not found.");
            }
        }
    }
}