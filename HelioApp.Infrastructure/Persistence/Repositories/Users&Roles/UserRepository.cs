using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;
using HelioApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Repositories
{
    public class UserRepository(HelioAppDbContext _context) : IUserRepository
    {

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            var users = await _context.Users.Where(u => u.AccountType != AccountType.Admin).AsNoTracking().ToListAsync();
            return users;
        }

        public async Task<ApplicationUser?> GetByIdAsync(string Id)
            => await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);

        public async Task<ApplicationUser?> GetByEmailAsync(string Email)
            => await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
        public async Task AddUserAsync(ApplicationUser User)
            => await _context.Users.AddAsync(User);

        public async Task UpdateUserAsync(ApplicationUser User)
            => _context.Users.Update(User);

        public async Task DeleteAllUsersAsync()
        {
            var allUsers = await _context.Users.Where(u => u.AccountType != AccountType.Admin).ToListAsync();

            if (allUsers.Any())
                _context.Users.RemoveRange(allUsers);
        }


        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();

    }
}
