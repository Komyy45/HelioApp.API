using AutoMapper;
using HelioApp.Application.DTOs.Community;
using HelioApp.Domain.Entities.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelioApp.Application.MappingProfiles
{
    public class DiscussionCircleMappingProfile : Profile
    {
        public DiscussionCircleMappingProfile()
        {
            CreateMap<DiscussionCircle, DiscussionCircleDto>();

            CreateMap<CreateDiscussionCircleDto, DiscussionCircle>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTimeOffset.UtcNow));

            CreateMap<UpdateDiscussionCircleDto, DiscussionCircle>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTimeOffset.UtcNow));
        }
    }
}
