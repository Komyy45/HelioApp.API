using System.Text;
using HelioApp.API.Middlewares;
using HelioApp.Application;
using HelioApp.Infrastructure;
using HelioApp.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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

        
        builder.Services.AddControllers();

        
        #region Swagger Setting (JWT)
        builder.Services.AddSwaggerGen(c =>
      {
          c.SwaggerDoc("v1", new OpenApiInfo { Title = "HelioApp API", Version = "v1" });

          c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
          {
              Name = "Authorization",
              Type = SecuritySchemeType.Http,
              Scheme = "Bearer",
              BearerFormat = "JWT",
              In = ParameterLocation.Header,
              Description = "Enter JWT Token"
          });

          c.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
          });
      }); 
        #endregion

        
        builder.Services.AddApplicationServices()
                        .AddInfrastructureServices(builder.Configuration);

        
        builder.Services.AddSingleton<GlobalExceptionHandlingMiddleware>();


        #region  JWT Authentication
        var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>()!;
        var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };
        });

        #endregion
        builder.Services.AddAuthorization();
    }
}
