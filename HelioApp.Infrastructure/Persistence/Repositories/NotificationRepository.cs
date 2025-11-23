using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Infrastructure.Persistence.Data;
using HelioApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Repositories
{
    public class NotificationRepository : GenericRepository<Notification, Guid>, INotificationRepository
    {
        private readonly HelioAppDbContext _dbContext;

        public NotificationRepository(HelioAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /* public async Task<IEnumerable<Notification>> GetActiveNotificationsAsync()
        {
            return await _dbContext.Set<Notification>()
                .Where(n => n.IsActive && n.StartDate <= DateTime.UtcNow && n.EndDate >= DateTime.UtcNow)
                .ToListAsync();
        }
        */
    }
}