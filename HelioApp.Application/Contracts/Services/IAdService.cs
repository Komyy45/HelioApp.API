using HelioApp.Application.DTOs.ContentManagement;

namespace HelioApp.Application.Contracts.Services;

public interface IAdService
{
    public Task<IEnumerable<AdDto>> GetAll();

    public Task<Guid> Create(CreateAdDto request);

    public Task Update(UpdateAdDto request);

    public Task Delete(Guid id);
}