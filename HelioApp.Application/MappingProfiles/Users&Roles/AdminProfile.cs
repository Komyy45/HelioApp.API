using AutoMapper;
using HelioApp.Application.DTOs.Users_Roles.RolesDTO;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;
using BCrypt.Net;

namespace HelioApp.Application.MappingProfiles.Users_Roles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<ApplicationUser, AdminResponse>()
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => src.AccountType.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<CreateUpdateAdminRequest, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName ?? src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)))
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => AccountType.Admin))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => AccountStatus.Active))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.UtcNow))
                .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper()));

        }
    }
}
