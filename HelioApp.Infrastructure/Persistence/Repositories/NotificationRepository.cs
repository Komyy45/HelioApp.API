using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Infrastructure.Persistence.Data;

namespace HelioApp.Infrastructure.Persistence.Repositories;

internal sealed class NotificationRepository(HelioAppDbContext context) : GenericRepository<Notification, Guid>(context)
{
    
}