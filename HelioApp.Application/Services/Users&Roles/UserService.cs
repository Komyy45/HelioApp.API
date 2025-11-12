using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelioApp.Application.Contracts.Authentication.Users_Roles;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.DTOs.Authentication;
using HelioApp.Application.DTOs.Users_Roles;
using HelioApp.Application.DTOs.Users_Roles.UsersDTO;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Application.Services.Users_Roles
{
    public class UserService(IUserRepository _userRepository, IMapper _mapper) : IUserService
    {
        public async Task<IEnumerable<UsersResponse>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UsersResponse>>(users);
        }

        public async Task<UsersResponse?> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UsersResponse>(user);
        }

        public async Task<bool> UpdateUserAsync(string id, UpdateUserRequest request)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            _mapper.Map(request, user);
            user.NormalizedEmail = user.Email.ToUpperInvariant();
            user.UpdatedAt = DateTimeOffset.UtcNow;

            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAllUsersAsync()
        {
            await _userRepository.DeleteAllUsersAsync();
            await _userRepository.SaveChangesAsync();
            return true;
        }

    }
}
