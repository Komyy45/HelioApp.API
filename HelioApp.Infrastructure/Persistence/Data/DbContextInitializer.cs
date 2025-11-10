using HelioApp.Application.Contracts;
using HelioApp.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Data;

internal sealed class DbContextInitializer(HelioAppDbContext helioAppDbContext) : IDbContextInitializer
{
    public async Task InitializeAsync()
    {
       await MigrateAsync();
       await SeedAsync();
    }

    private async Task SeedAsync()
    {
        // if (!userManager.Users.Any())
        // {
        //     string email = "admin@gmail.com";
        //     string userName = "admin";
        //     string phone = "+201234567890";
        //     
        //     var applicationUser = new ApplicationUser()
        //     {
        //         Email = email,
        //         UserName = userName,
        //         PhoneNumber = phone
        //     };
        //
        //     await userManager.CreateAsync(applicationUser, "P@ssw0rd");
        // }
    }


    private async Task MigrateAsync()
    {
        var migrations = await helioAppDbContext.Database.GetPendingMigrationsAsync();

        if (migrations.Any())
            await helioAppDbContext.Database.MigrateAsync();
    }
}