using HelioApp.Application.Contracts;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;
using HelioApp.Infrastructure.Authentication;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Data;

internal sealed class DbContextInitializer : IDbContextInitializer
{
    private readonly HelioAppDbContext _context;

    public DbContextInitializer(HelioAppDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        await MigrateAsync();
        await SeedAsync();
    }

    private async Task MigrateAsync()
    {
        var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
        if (pendingMigrations.Any())
            await _context.Database.MigrateAsync();
    }

    private async Task SeedAsync()
    {
        // Seed Roles
        if (!await _context.Roles.AnyAsync())
        {
            await _context.Roles.AddRangeAsync(
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    Description = "System administrator"
                },
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    Description = "Regular user"
                }
            );
        }

        // Seed Admin User
        if (!await _context.Users.AnyAsync(u => u.AccountType == AccountType.Admin))
        {
            var adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "admin@helio.com",
                NormalizedEmail = "ADMIN@HELIO.COM",
                UserName = "admin",
                PhoneNumber = "+201234567890",
                PasswordHash = new PasswordHasher().HashPassword("P@ssw0rd"),
                AccountType = AccountType.Admin,
                Status = AccountStatus.Active,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await _context.Users.AddAsync(adminUser);
        }

        await _context.SaveChangesAsync();
    }
}
