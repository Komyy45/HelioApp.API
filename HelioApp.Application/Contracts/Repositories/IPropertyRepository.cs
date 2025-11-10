using HelioApp.Domain.Entities.Properties;

namespace HelioApp.Application.Contracts.Repositories;

public interface IPropertyRepository : IGenericRepository<Property,Guid>
{
}