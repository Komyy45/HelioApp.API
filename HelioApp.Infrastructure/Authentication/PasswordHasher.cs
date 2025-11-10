using System.Text.RegularExpressions;
using HelioApp.Application.Contracts.Authentication;

namespace HelioApp.Infrastructure.Authentication;

internal sealed class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        throw new NotImplementedException();
    }

    public bool IsCorrectPassword(string passwordHash, string password)
    {
        throw new NotImplementedException();
    }

//     [GeneratedRegex("")]
//     public partial static Regex StrongPasswordRegex();
}