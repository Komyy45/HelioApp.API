using CloudinaryDotNet;
using HelioApp.Application.Contracts;
using HelioApp.Application.Contracts.Authentication;
using HelioApp.Application.Contracts.Blob;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Repositories.Users_Roles;
using HelioApp.Infrastructure.Authentication;
using HelioApp.Infrastructure.Blob;
using HelioApp.Infrastructure.Persistence.Data;
using HelioApp.Infrastructure.Persistence.Repositories;
using HelioApp.Infrastructure.Persistence.Repositories.Users_Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelioApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<HelioAppDbContext>(opt => opt.UseSqlServer(connectionString));

        services.Configure<CloudinaryOptions>(configuration.GetSection("Cloudinary"));
        services.AddScoped<IImageService, CloudinaryImageService>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<IOfferClaimRepository, OfferClaimRepository>();
        services.AddScoped<IOfferCodeRepository, OfferCodeRepository>();
        services.AddScoped<IEmergencyContactsRepository, EmergencyContactsRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();

        // Authentication
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddScoped<IAuthTokenGenerator, JwtBearerTokenGenerator>();

        services.AddScoped<IDbContextInitializer, DbContextInitializer>();

        return services;
    }
}
