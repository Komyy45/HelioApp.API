using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Application.Contracts.Repositories.Users_Roles
{
    public interface IAdminRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllAdminsAsync();
        Task<ApplicationUser?> GetAdminByIdAsync(string Id);
        Task AddAdminAsync(ApplicationUser admin);
        Task UpdateAdminAsync(ApplicationUser admin);
        Task DeleteAdminAsync(string Id);
        Task SaveChangesAsync();
    }
}
