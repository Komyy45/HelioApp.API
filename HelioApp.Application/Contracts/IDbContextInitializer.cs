namespace HelioApp.Application.Contracts;

public interface IDbContextInitializer
{
    public Task InitializeAsync();
}