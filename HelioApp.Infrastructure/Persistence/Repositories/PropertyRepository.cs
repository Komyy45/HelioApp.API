using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.Properties;
using HelioApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Repositories;

internal sealed class PropertyRepository(HelioAppDbContext context) : GenericRepository<Property, Guid>(context), IPropertyRepository
{
    private readonly DbSet<Property> _properties = context.Properties;
}