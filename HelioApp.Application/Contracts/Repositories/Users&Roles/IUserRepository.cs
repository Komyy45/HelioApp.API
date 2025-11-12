using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser?> GetByEmailAsync(string Email);
        Task<ApplicationUser?> GetByIdAsync(string Id);
        Task AddUserAsync(ApplicationUser User);
        Task UpdateUserAsync(ApplicationUser User);
        Task DeleteAllUsersAsync();
        Task SaveChangesAsync();
    }
}
