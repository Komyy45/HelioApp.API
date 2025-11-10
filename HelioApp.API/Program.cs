using HelioApp.API;
using HelioApp.API.Extensions;
using HelioApp.API.Middlewares;
using HelioApp.Domain.Entities.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureWebApplication();

var app = builder.Build();

await app.InitializeDatabaseAsync();

// // Configure middleware
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
//     app.MapOpenApi();
// }

app.UseSwagger();
app.UseSwaggerUI();
app.MapOpenApi();

app.UseCors("AllowAll");

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
