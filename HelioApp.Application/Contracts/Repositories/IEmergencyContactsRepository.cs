using HelioApp.Domain.Entities.CityServices;

namespace HelioApp.Application.Contracts.Repositories;

public interface IEmergencyContactsRepository : IGenericRepository<EmergencyContact, Guid>
{
    
}