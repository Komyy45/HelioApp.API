using HelioApp.Domain.Entities.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelioApp.Application.Contracts.Repositories
{
    public interface IDiscussionCircleRepository : IGenericRepository<DiscussionCircle, Guid>
    {
    }
}
