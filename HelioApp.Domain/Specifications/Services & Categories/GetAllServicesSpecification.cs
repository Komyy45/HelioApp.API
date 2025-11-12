using System.Linq.Expressions;
using HelioApp.Domain.Entities.Services___Categories;

namespace HelioApp.Domain.Specifications.Services___Categories;

public class GetAllServicesSpecification : BaseSpecifications<Service, Guid>
{
    public GetAllServicesSpecification(Expression<Func<Service, bool>> criteria, int pageIndex, int pageSize) : base(criteria)
    {
        AddPagination(take: pageSize, pageIndex == 0 ? 0 : (pageIndex - 1) * pageSize);
    }
}