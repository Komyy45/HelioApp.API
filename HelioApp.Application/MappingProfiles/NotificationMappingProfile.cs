// مثال للكود الذي يجب عليك إضافته
using AutoMapper;
using HelioApp.Application.DTOs.ContentManagement;
using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.MappingProfiles
{
    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<Notification, NotificationDto>()
                .ForMember(dest => dest.SpecificUserIds, opt => opt.MapFrom(src => src.SpecificUserIds));
            CreateMap<CreateNotificationDto, Notification>();
            CreateMap<UpdateNotificationDto, Notification>();
            CreateMap<UserNotification, UserBriefNotificationDto>()
                .ForMember(dest => dest.UserNotificationId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NotificationId, opt => opt.MapFrom(src => src.NotificationId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Notification.Title)) 
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Notification.Content))
                .ForMember(dest => dest.SentAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}