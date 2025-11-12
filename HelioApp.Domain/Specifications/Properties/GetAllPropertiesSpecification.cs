using System.Linq.Expressions;
using HelioApp.Domain.Entities.Properties;

namespace HelioApp.Domain.Specifications.Properties;

public class GetAllPropertiesSpecification : BaseSpecifications<Property, Guid>
{
    public GetAllPropertiesSpecification(Expression<Func<Property, bool>> criteria, int pageSize, int pageIndex) : base(criteria)
    {
        AddPagination(take: pageSize, skip: pageIndex == 0 ? 0 : (pageIndex - 1) * pageSize);
    }
}