using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelioApp.Application.DTOs.Users_Roles.RolesDTO;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Application.Contracts.Authentication.Users_Roles
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminResponse>> GetAllAdminsAsync();
        Task<AdminResponse?> GetAdminByIdAsync(string Id);
        Task<AdminResponse> AddAdminAsync(CreateUpdateAdminRequest dto);
        Task<bool> UpdateAdminAsync(string Id, CreateUpdateAdminRequest dto);
        Task<bool> DeleteAdminAsync(string Id);
    }
}
