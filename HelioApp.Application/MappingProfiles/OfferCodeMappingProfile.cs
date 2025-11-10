using AutoMapper;
using HelioApp.Application.DTOs.Offers;
using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.MappingProfiles
{
    public class OfferCodeMappingProfile : Profile
    {
        public OfferCodeMappingProfile()
        {
            CreateMap<OfferCode, OfferCodeDto>();
            CreateMap<CreateOfferCodeDto, OfferCode>();
            CreateMap<UpdateOfferCodeDto, OfferCode>();
        }
    }
}