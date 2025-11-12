using AutoMapper;
using HelioApp.Application.Contracts.Authentication.Users_Roles;
using HelioApp.Application.Contracts.Repositories.Users_Roles;
using HelioApp.Application.DTOs.Users_Roles.RolesDTO;
using HelioApp.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity;
using HelioApp.Domain.Enums;

namespace HelioApp.Application.Services.Users_Roles
{
    public class AdminService(IAdminRepository _adminRepository, IMapper _mapper) : IAdminService
    {
        private readonly IAdminRepository _repo = _adminRepository;
        private readonly IMapper _mapperInstance = _mapper;

        public async Task<IEnumerable<AdminResponse>> GetAllAdminsAsync()
        {
            var admins = await _repo.GetAllAdminsAsync();
            return _mapperInstance.Map<IEnumerable<AdminResponse>>(admins);
        }

        public async Task<AdminResponse?> GetAdminByIdAsync(string Id)
        {
            var admin = await _repo.GetAdminByIdAsync(Id);
            return admin == null ? null : _mapperInstance.Map<AdminResponse>(admin);
        }

        public async Task<AdminResponse> AddAdminAsync(CreateUpdateAdminRequest dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Email)) throw new ArgumentException("Email required.");
            if (string.IsNullOrWhiteSpace(dto.Password)) throw new ArgumentException("Password required.");

            var admin = _mapperInstance.Map<ApplicationUser>(dto);
            admin.Id = Guid.NewGuid().ToString();
            admin.AccountType = AccountType.Admin;
            admin.Status = Domain.Enums.AccountStatus.Active;
            admin.CreatedAt = DateTimeOffset.UtcNow;
            admin.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(admin, dto.Password);

            await _repo.AddAdminAsync(admin);
            await _repo.SaveChangesAsync();

            return _mapperInstance.Map<AdminResponse>(admin);
        }

        public async Task<bool> UpdateAdminAsync(string Id, CreateUpdateAdminRequest dto)
        {
            var admin = await _repo.GetAdminByIdAsync(Id);
            if (admin == null) return false;

            _mapperInstance.Map(dto, admin);
            if (!string.IsNullOrEmpty(dto.Password))
                admin.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(admin, dto.Password);

            await _repo.UpdateAdminAsync(admin);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAdminAsync(string Id)
        {
            var admin = await _repo.GetAdminByIdAsync(Id);
            if (admin == null) return false;

            await _repo.DeleteAdminAsync(Id);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
