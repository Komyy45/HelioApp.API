using HelioApp.API.Middlewares;
using HelioApp.Application;
using HelioApp.Infrastructure;

namespace HelioApp.API;

public static class DependencyInjection
{
     public static void ConfigureWebApplication(this WebApplicationBuilder builder)
     {
         builder.Services.AddCors(options =>
         {
             options.AddPolicy("AllowAll", policy =>
                 policy.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
         });
         
         builder.Services.AddOpenApi();
         builder.Services.AddControllers();
         builder.Services.AddSwaggerGen();
         
          builder.Services.AddApplicationServices()
                          .AddInfrastructureServices(builder.Configuration);
         

          builder.Services.AddSingleton<GlobalExceptionHandlingMiddleware>();
     }
}