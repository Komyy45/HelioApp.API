using AutoMapper;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Offers;
using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Domain.Exceptions;

namespace HelioApp.Application.Services
{
    internal sealed class OfferCodeService(
        IOfferCodeRepository offerCodeRepository,
        IMapper mapper 
    ) : IOfferCodeService
    {

        public async Task<IEnumerable<OfferCodeDto>> GetAllAsync()
        {
            var codes = await offerCodeRepository.GetAllAsync();
            return mapper.Map<IEnumerable<OfferCodeDto>>(codes);
        }

        public async Task<OfferCodeDto?> GetByIdAsync(Guid id)
        {
            var code = await offerCodeRepository.GetByIdAsync(id);
            if (code is null) throw new NotFoundException(nameof(OfferCode));

            return mapper.Map<OfferCodeDto>(code);
        }

        public async Task<OfferCodeDto> CreateAsync(CreateOfferCodeDto dto)
        {
            var existingCode = await offerCodeRepository.GetByCodeAsync(dto.Code);
            if (existingCode is not null)
            {
                throw new ApplicationException($"Offer Code '{dto.Code}' already exists.");
            }
            var code = mapper.Map<OfferCode>(dto);

            await offerCodeRepository.AddAsync(code);
            await offerCodeRepository.CompleteAsync();

            return mapper.Map<OfferCodeDto>(code);
        }

        public async Task UpdateAsync(UpdateOfferCodeDto dto)
        {
            var code = await offerCodeRepository.GetByIdAsync(dto.Id);
            if (code is null) throw new NotFoundException(nameof(OfferCode));
            if (code.IsUsed && dto.IsUsed == false)
            {
                throw new ApplicationException("Cannot revert used code status.");
            }

            mapper.Map(dto, code);

            offerCodeRepository.Update(code);
            await offerCodeRepository.CompleteAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var code = await offerCodeRepository.GetByIdAsync(id);
            if (code is null) return false;
            if (code.IsUsed)
            {
                throw new ApplicationException("Cannot delete a used offer code.");
            }

            offerCodeRepository.Delete(code);
            await offerCodeRepository.CompleteAsync();
            return true;
        }
    }
}