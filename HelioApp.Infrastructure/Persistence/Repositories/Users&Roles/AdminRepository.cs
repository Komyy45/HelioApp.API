using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelioApp.Application.Contracts.Repositories.Users_Roles;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;
using HelioApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Repositories.Users_Roles
{
    public class AdminRepository(HelioAppDbContext _context) : IAdminRepository
    {


        public async Task<IEnumerable<ApplicationUser>> GetAllAdminsAsync()
        {
            return await _context.Users
                .Where(u => u.AccountType == AccountType.Admin)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ApplicationUser?> GetAdminByIdAsync(string Id)
             => await _context.Users.FirstOrDefaultAsync(u => u.Id == Id && u.AccountType == AccountType.Admin);

        public async Task AddAdminAsync(ApplicationUser admin)
            => await _context.Users.AddAsync(admin);

        public async Task UpdateAdminAsync(ApplicationUser admin)
            => _context.Users.Update(admin);

        public async Task DeleteAdminAsync(string Id)
        {
            var admin = await _context.Users.FindAsync(Id);
            if (admin != null && admin.AccountType == AccountType.Admin)
                _context.Users.Remove(admin);
        }

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
