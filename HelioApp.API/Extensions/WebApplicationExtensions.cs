using HelioApp.Application.Contracts;

namespace HelioApp.API.Extensions;

internal static class WebApplicationExtensions
{
    public static async Task<WebApplication> InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        try
        {
            var dbContextInitializer = scope.ServiceProvider.GetRequiredService<IDbContextInitializer>();
            await dbContextInitializer.InitializeAsync();
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex.StackTrace);
        }

        return app;
    }
}