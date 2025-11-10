using HelioApp.Application.DTOs.CityServices;

namespace HelioApp.Application.Contracts.Services;

public interface IEmergencyContactsService
{
    public Task<IEnumerable<EmergencyContactDto>> GetAll();

    public Task<Guid> Create(CreateEmergencyContactDto request);

    public Task Update(UpdateEmergencyContactDto request);

    public Task Delete(Guid id);
}