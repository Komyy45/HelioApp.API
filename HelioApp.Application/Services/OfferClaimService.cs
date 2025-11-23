using AutoMapper;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Offers;
using HelioApp.Domain.Exceptions; 
using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.Services
{

    internal sealed class OfferClaimService(
        IOfferClaimRepository offerClaimRepository,
        IMapper mapper
    ) : IOfferClaimService
    {
        public async Task<IEnumerable<OfferClaimDto>> GetAllAsync()
        {
            var claims = await offerClaimRepository.GetAllAsync();
            return mapper.Map<IEnumerable<OfferClaimDto>>(claims);
        }

        public async Task<OfferClaimDto?> GetByIdAsync(Guid id)
        {
            var claim = await offerClaimRepository.GetByIdAsync(id);
            if (claim is null) throw new NotFoundException(nameof(OfferClaim));

            return mapper.Map<OfferClaimDto>(claim);
        }

        public async Task<OfferClaimDto> CreateAsync(CreateOfferClaimDto dto)
        {
            var alreadyClaimed = await offerClaimRepository.IsUserAlreadyClaimedAsync(
                dto.OfferId, dto.UserId);

            if (alreadyClaimed)
            {
                throw new ApplicationException("User has already claimed this offer.");
            }


            var claim = mapper.Map<OfferClaim>(dto);

            await offerClaimRepository.AddAsync(claim);
            await offerClaimRepository.CompleteAsync();

            return mapper.Map<OfferClaimDto>(claim);
        }

        public async Task UpdateAsync(UpdateOfferClaimDto dto)
        {
            var claim = await offerClaimRepository.GetByIdAsync(dto.Id);
            if (claim is null) throw new NotFoundException(nameof(OfferClaim));

            mapper.Map(dto, claim);

            offerClaimRepository.Update(claim);
            await offerClaimRepository.CompleteAsync();
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            var claim = await offerClaimRepository.GetByIdAsync(id);
            if (claim is null) return false;

            offerClaimRepository.Delete(claim);
            await offerClaimRepository.CompleteAsync();
            return true;
        }
    }
}