using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;

namespace HelioApp.Application.Services;

internal sealed class AdService(IAdRepository adRepository) : IAdService
{
    public Task<IEnumerable<AdDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Create(CreateAdDto request)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateAdDto request)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}