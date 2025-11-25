using AutoMapper;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;
using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.Services;

internal sealed class AdService(IAdRepository adRepository, IMapper mapper) : IAdService
{
    public async Task<IEnumerable<AdDto>> GetAll()
    {
        var ads = await adRepository.GetAllAsync();
        return mapper.Map<IEnumerable<AdDto>>(ads);
    }

    public async Task<Guid> Create(CreateAdDto request)
    {
        var entity = mapper.Map<Ad>(request);

        await adRepository.AddAsync(entity);
        await adRepository.CompleteAsync();

        return entity.Id;
    }


    public async Task Update(UpdateAdDto request)
    {
        var existing = await adRepository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException("Ad not found");

        mapper.Map(request, existing);

        adRepository.Update(existing);
        await adRepository.CompleteAsync();
    }

    public async Task Delete(Guid id)
    {
        var existing = await adRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("Ad not found");

        adRepository.Delete(existing);
        await adRepository.CompleteAsync();
    }
}