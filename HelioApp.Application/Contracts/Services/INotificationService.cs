using HelioApp.Application.DTOs.ContentManagement;

namespace HelioApp.Application.Contracts.Services;

public interface INotificationService
{
    Task<IEnumerable<NotificationDto>> GetAll();
    Task<Guid> Create(PushNotificationDto request);
    Task Update(UpdateNotificationDto dto);
    Task Delete(Guid id);
}