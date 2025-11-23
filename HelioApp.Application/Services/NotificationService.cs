using AutoMapper;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;
using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Domain.Exceptions; 

namespace HelioApp.Application.Services
{
    internal sealed class NotificationService(
        INotificationRepository notificationRepository,
        IMapper mapper
    ) : INotificationService
    {
        public async Task<IEnumerable<NotificationDto>> GetAll()
        {
            var notifications = await notificationRepository.GetAllAsync();
            return mapper.Map<IEnumerable<NotificationDto>>(notifications);
        }

        public async Task<NotificationDto> GetById(Guid id)
        {
            var notification = await notificationRepository.GetByIdAsync(id);
            if (notification is null)
            {
                throw new NotFoundException(nameof(Notification));
            }

            return mapper.Map<NotificationDto>(notification);
        }

        public async Task<Guid> Create(CreateNotificationDto request)
        {
            if (request.StartDate >= request.EndDate)
            {
                throw new ApplicationException("Start date must be before end date.");
            }

            var notification = mapper.Map<Notification>(request);

            await notificationRepository.AddAsync(notification);
            await notificationRepository.CompleteAsync();

            return notification.Id;
        }

        public async Task Update(UpdateNotificationDto dto)
        {
            var notification = await notificationRepository.GetByIdAsync(dto.Id);

            if (notification is null)
            {
                throw new NotFoundException(nameof(Notification));
            }

            if (notification.SentCount > 0)
            {
                throw new ApplicationException("Cannot update notification after it has started sending.");
            }

            mapper.Map(dto, notification);
            notification.UpdatedAt = DateTime.UtcNow;

            await notificationRepository.CompleteAsync();
        }

        public async Task Delete(Guid id)
        {
            var notification = await notificationRepository.GetByIdAsync(id);

            if (notification is null)
            {
                throw new NotFoundException(nameof(Notification));
            }

            if (notification.SentCount > 0)
            {
                throw new ApplicationException("Cannot delete a notification that has already been sent.");
            }

            notificationRepository.Delete(notification);
            await notificationRepository.CompleteAsync();
        }
    }
}