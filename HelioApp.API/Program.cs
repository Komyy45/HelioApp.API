using HelioApp.API;
using HelioApp.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureWebApplication();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<HelioApp.Application.Contracts.IDbContextInitializer>();
    await dbInitializer.InitializeAsync();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelioApp API V1"));

app.UseCors("AllowAll");

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
