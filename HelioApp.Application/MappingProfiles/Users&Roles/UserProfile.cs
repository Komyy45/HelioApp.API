using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelioApp.Application.DTOs.Users_Roles;
using HelioApp.Application.DTOs.Users_Roles.UsersDTO;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Application.MappingProfiles.Users_Roles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UsersResponse>();

            CreateMap<UpdateUserRequest, ApplicationUser>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.UtcNow));
        }
    }
}
