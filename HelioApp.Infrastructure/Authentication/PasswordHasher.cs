using System.Text.RegularExpressions;
using HelioApp.Application.Contracts.Authentication;

namespace HelioApp.Infrastructure.Authentication;

internal sealed class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool IsCorrectPassword(string passwordHash, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }

//     [GeneratedRegex("")]
//     public partial static Regex StrongPasswordRegex();
}