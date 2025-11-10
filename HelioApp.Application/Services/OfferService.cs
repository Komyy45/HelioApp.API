using AutoMapper;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Offers;
using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.Services
{
    internal sealed class OfferService(IOfferRepository offerRepository, IMapper mapper)
        : IOfferService
    {
        public async Task<IEnumerable<OfferDto>> GetAllAsync()
        {
            var offers = await offerRepository.GetAllAsync();
            return mapper.Map<IEnumerable<OfferDto>>(offers);
        }

        public async Task<OfferDto?> GetByIdAsync(Guid id)
        {
            var offer = await offerRepository.GetByIdAsync(id);
            if (offer is null) throw new Exception("Offer Not Found!");
            return mapper.Map<OfferDto>(offer);
        }

        public async Task<OfferDto> CreateAsync(CreateOfferDto dto)
        {
            var offer = mapper.Map<Offer>(dto);
            await offerRepository.AddAsync(offer);
            await offerRepository.CompleteAsync();
            return mapper.Map<OfferDto>(offer);
        }

        public async Task UpdateAsync(UpdateOfferDto dto)
        {
            var offer = await offerRepository.GetByIdAsync(dto.Id);
            if (offer is null) throw new Exception("Offer Not Found!");

            mapper.Map(dto, offer);
            offerRepository.Update(offer);
            await offerRepository.CompleteAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var offer = await offerRepository.GetByIdAsync(id);
            if (offer is null) return false;
            offerRepository.Delete(offer);
            await offerRepository.CompleteAsync();
            return true;
        }
    }
}
