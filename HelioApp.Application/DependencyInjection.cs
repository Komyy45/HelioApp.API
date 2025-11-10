using HelioApp.Application.Contracts;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.MappingProfiles;
using HelioApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HelioApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(opt =>
        { 
            opt.AddProfile<OfferClaimProfile>();
            opt.AddProfile<OfferCodeMappingProfile>();
            opt.AddProfile<OfferProfile>();
        });
        
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<ISubcategoryService, SubcategoryService>();
        services.AddScoped<IOfferService, OfferService>();
        services.AddScoped<IOfferClaimService, OfferClaimService>();
        services.AddScoped<IOfferCodeService, OfferCodeService>();
        services.AddScoped<IEmergencyContactsService, EmergencyContactsService>();
        services.AddScoped<IPropertyService, PropertyService>();
        
        
        return services;
    }
}