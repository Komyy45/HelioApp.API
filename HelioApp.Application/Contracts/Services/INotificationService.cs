using HelioApp.Application.DTOs.ContentManagement;

namespace HelioApp.Application.Contracts.Services;

public interface INotificationService
{
    Task<IEnumerable<NotificationDto>> GetAll();
    Task<NotificationDto> GetById(Guid id); 
    Task<Guid> Create(CreateNotificationDto request); 
    Task Update(UpdateNotificationDto dto);
    Task Delete(Guid id);
}