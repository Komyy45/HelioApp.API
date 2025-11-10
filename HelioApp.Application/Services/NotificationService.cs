using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;

namespace HelioApp.Application.Services;

internal sealed class NotificationService : INotificationService
{
    public Task<IEnumerable<NotificationDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Create(PushNotificationDto request)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateNotificationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}