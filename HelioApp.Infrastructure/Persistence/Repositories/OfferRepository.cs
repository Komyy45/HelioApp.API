using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Infrastructure.Persistence.Data;

namespace HelioApp.Infrastructure.Persistence.Repositories
{
    public class OfferRepository(HelioAppDbContext context) : GenericRepository<Offer, Guid>(context), IOfferRepository;
}
