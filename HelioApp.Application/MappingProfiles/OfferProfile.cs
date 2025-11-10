using AutoMapper;
using HelioApp.Application.DTOs.Offers;
using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.MappingProfiles
{
    public sealed class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<Offer, OfferDto>().ReverseMap();
            CreateMap<CreateOfferDto, Offer>();
            CreateMap<UpdateOfferDto, Offer>();
        }
    }
}
