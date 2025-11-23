using AutoMapper;
using HelioApp.Application.DTOs.Offers;
using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Domain.Enums;

namespace HelioApp.Application.MappingProfiles
{
    public sealed class OfferProfile : Profile
    {
        public OfferProfile()
        {
            // Offer -> OfferDto
            CreateMap<Offer, OfferDto>()
                .ForMember(dest => dest.OfferType, opt => opt.MapFrom(src => src.OfferType.ToString()))
                .ForMember(dest => dest.RedemptionMethod, opt => opt.MapFrom(src => src.RedemptionMethod.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.UtcDateTime))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.UtcDateTime));

            // CreateOfferDto -> Offer
            CreateMap<CreateOfferDto, Offer>()
                .ForMember(dest => dest.OfferType, opt => opt.MapFrom(src => Enum.Parse<OfferType>(src.OfferType)))
                .ForMember(dest => dest.RedemptionMethod, opt => opt.MapFrom(src => Enum.Parse<RedemptionMethod>(src.RedemptionMethod)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<OfferStatus>(src.Status)))
                .ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.CreatedBy.ToString()))
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => new DateTimeOffset(src.StartDate)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => new DateTimeOffset(src.EndDate)));


            // UpdateOfferDto -> Offer
            CreateMap<UpdateOfferDto, Offer>()
                .ForMember(dest => dest.OfferType, opt => opt.MapFrom(src => Enum.Parse<OfferType>(src.OfferType)))
                .ForMember(dest => dest.RedemptionMethod, opt => opt.MapFrom(src => Enum.Parse<RedemptionMethod>(src.RedemptionMethod)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<OfferStatus>(src.Status)))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => new DateTimeOffset(src.StartDate)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => new DateTimeOffset(src.EndDate)));
        }
    }
}
