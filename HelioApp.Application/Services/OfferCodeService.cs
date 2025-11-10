using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Offers;
using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.Services
{
    internal sealed class OfferCodeService(IOfferCodeRepository offerCodeRepository)
        : IOfferCodeService
    {
        public async Task<IEnumerable<OfferCodeDto>> GetAllAsync()
        {
            var codes = await offerCodeRepository.GetAllAsync();
            return codes.Select(c => new OfferCodeDto(
                c.Id, c.OfferId, c.Code, c.IsUsed,
                c.UsedBy.ToString(), c.UsedAt, c.ExpiresAt, c.CreatedAt
            ));
        }

        public async Task<OfferCodeDto?> GetByIdAsync(Guid id)
        {
            var code = await offerCodeRepository.GetByIdAsync(id);
            if (code is null) throw new Exception("Offer Code not found");

            return new OfferCodeDto(
                code.Id, code.OfferId, code.Code, code.IsUsed,
                code.UsedBy.ToString(), code.UsedAt, code.ExpiresAt, code.CreatedAt
            );
        }

        public async Task<OfferCodeDto> CreateAsync(CreateOfferCodeDto dto)
        {
            var code = new OfferCode
            {
                OfferId = dto.OfferId,
                Code = dto.Code,
                ExpiresAt = dto.ExpiresAt,
            };

            await offerCodeRepository.AddAsync(code);
            await offerCodeRepository.CompleteAsync();

            return new OfferCodeDto(
                code.Id, code.OfferId, code.Code, code.IsUsed,
                code.UsedBy.ToString(), code.UsedAt, code.ExpiresAt, code.CreatedAt
            );
        }

        public async Task UpdateAsync(UpdateOfferCodeDto dto)
        {
            var code = await offerCodeRepository.GetByIdAsync(dto.Id);
            if (code is null) throw new Exception("Offer Code not found");

            code.IsUsed = dto.IsUsed;
            code.UsedBy = dto.UsedBy.ToString();
            code.UsedAt = dto.UsedAt;

            offerCodeRepository.Update(code);
            await offerCodeRepository.CompleteAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var code = await offerCodeRepository.GetByIdAsync(id);
            if (code is null) return false;

            offerCodeRepository.Delete(code);
            await offerCodeRepository.CompleteAsync();
            return true;
        }
    }
}
