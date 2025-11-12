using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelioApp.Application.DTOs.Authentication;
using HelioApp.Application.DTOs.Users_Roles;
using HelioApp.Application.DTOs.Users_Roles.UsersDTO;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Application.Contracts.Authentication.Users_Roles
{
    public interface IUserService
    {
        Task<IEnumerable<UsersResponse>> GetAllUsersAsync();
        Task<UsersResponse?> GetUserByIdAsync(string Id);
        Task<bool> UpdateUserAsync(string Id, UpdateUserRequest request);
        Task<bool> DeleteAllUsersAsync();
    }
}
