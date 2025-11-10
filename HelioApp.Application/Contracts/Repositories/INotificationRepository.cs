using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.Contracts.Repositories;

public interface INotificationRepository : IGenericRepository<Notification, Guid>
{ }