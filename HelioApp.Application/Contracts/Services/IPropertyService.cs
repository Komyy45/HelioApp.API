using HelioApp.Application.DTOs.Common;
using HelioApp.Application.DTOS.Properties;

namespace HelioApp.Application.Contracts.Services;

public interface IPropertyService
{
    public Task<PaginationResponse<PropertyDto>> GetAll(PaginationRequest request);
    public Task<PropertyDetailsDto> GetById(Guid id);
    public Task<Guid> Create(CreatedPropertyDto createdProperty);
    public Task Update(UpdatedPropertyDto updatedProperty);
    public Task Delete(Guid id);
}