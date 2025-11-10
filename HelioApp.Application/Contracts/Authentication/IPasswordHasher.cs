namespace HelioApp.Application.Contracts.Authentication;

public interface IPasswordHasher
{
   public string HashPassword(string password);
   public bool IsCorrectPassword(string passwordHash, string password);
}