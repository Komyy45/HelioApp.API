using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.CityServices;
using HelioApp.Infrastructure.Persistence.Data;

namespace HelioApp.Infrastructure.Persistence.Repositories;

internal sealed class EmergencyContactsRepository(HelioAppDbContext context) 
    : GenericRepository<EmergencyContact, Guid>(context), 
    IEmergencyContactsRepository
{
    
}