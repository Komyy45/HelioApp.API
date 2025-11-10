using AutoMapper;
using HelioApp.Application.DTOs.Offers;
using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.MappingProfiles
{
    public class OfferClaimProfile : Profile
    {
        public OfferClaimProfile()
        {
            CreateMap<OfferClaim, OfferClaimDto>();
            CreateMap<CreateOfferClaimDto, OfferClaim>();
            CreateMap<UpdateOfferClaimDto, OfferClaim>();
        }
    }
}
