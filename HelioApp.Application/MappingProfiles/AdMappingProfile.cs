using AutoMapper;
using HelioApp.Domain.Entities.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelioApp.Application.MappingProfiles
{
    public class AdMappingProfile : Profile
    {
        public AdMappingProfile()
        {
            CreateMap<Ad, AdDto>();

            CreateMap<CreateAdDto, Ad>()
                .ForMember(d => d.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<UpdateAdDto, Ad>()
                .ForMember(d => d.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
        }
    }
}
