using CloudinaryDotNet;
using HelioApp.Application.Contracts;
using HelioApp.Application.Contracts.Blob;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Infrastructure.Blob;
using HelioApp.Infrastructure.Persistence.Data;
using HelioApp.Infrastructure.Persistence.Repositories;
using HelioApp.Infrastructure.Repositories;
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

        services.Configure<CloudinaryOptions>(cloudinaryOptions =>
            {
                var section = configuration.GetSection("Cloudinary");

                cloudinaryOptions.ApiKey = section[nameof(CloudinaryOptions.ApiKey)]!;
                cloudinaryOptions.ApiSecret = section[nameof(CloudinaryOptions.ApiSecret)]!;
                cloudinaryOptions.Cloud = section[nameof(CloudinaryOptions.Cloud)]!;
            });
        
        services.AddScoped<IImageService, CloudinaryImageService>();
        
        //services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        // services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<IOfferClaimRepository, OfferClaimRepository>();
        services.AddScoped<IOfferCodeRepository, OfferCodeRepository>();
        services.AddScoped<IEmergencyContactsRepository, EmergencyContactsRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IUserNotificationRepository, UserNotificationRepository>();
        services.AddScoped<IAdRepository, AdRepository>();
        services.AddScoped<IDbContextInitializer, DbContextInitializer>();
        return services;
    }
}
