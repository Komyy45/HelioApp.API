using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Offers;
using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.Services
{
    internal sealed class OfferClaimService(IOfferClaimRepository offerClaimRepository)
        : IOfferClaimService
    {
        public async Task<IEnumerable<OfferClaimDto>> GetAllAsync()
        {
            var claims = await offerClaimRepository.GetAllAsync();
            return claims.Select(c => new OfferClaimDto(
                c.Id, c.OfferId, c.UserId, c.ClaimCode,
                c.IsRedeemed, c.RedeemedAt, c.RedemptionLocation,
                c.ExpiresAt, c.ClaimedAt
            ));
        }

        public async Task<OfferClaimDto?> GetByIdAsync(Guid id)
        {
            var claim = await offerClaimRepository.GetByIdAsync(id);
            if (claim is null) throw new Exception("Offer Claim not found");

            return new OfferClaimDto(
                claim.Id, claim.OfferId, claim.UserId, claim.ClaimCode,
                claim.IsRedeemed, claim.RedeemedAt, claim.RedemptionLocation,
                claim.ExpiresAt, claim.ClaimedAt
            );
        }

        public async Task<OfferClaimDto> CreateAsync(CreateOfferClaimDto dto)
        {
            var claim = new OfferClaim
            {
                OfferId = dto.OfferId,
                UserId = dto.UserId.ToString(),
                ClaimCode = dto.ClaimCode,
                ExpiresAt = dto.ExpiresAt,
            };

            await offerClaimRepository.AddAsync(claim);
            await offerClaimRepository.CompleteAsync();

            return new OfferClaimDto(
                claim.Id, claim.OfferId, claim.UserId, claim.ClaimCode,
                claim.IsRedeemed, claim.RedeemedAt, claim.RedemptionLocation,
                claim.ExpiresAt, claim.ClaimedAt
            );
        }

        public async Task UpdateAsync(UpdateOfferClaimDto dto)
        {
            var claim = await offerClaimRepository.GetByIdAsync(dto.Id);
            if (claim is null) throw new Exception("Offer Claim not found");

            claim.IsRedeemed = dto.IsRedeemed;
            claim.RedeemedAt = dto.RedeemedAt;
            claim.RedemptionLocation = dto.RedemptionLocation;
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
