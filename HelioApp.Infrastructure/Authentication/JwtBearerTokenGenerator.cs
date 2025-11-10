using System.Security.Claims;
using HelioApp.Application.Contracts.Authentication;

namespace HelioApp.Infrastructure.Authentication;

internal sealed class JwtBearerTokenGenerator : IAuthTokenGenerator
{
    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        throw new NotImplementedException();
    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }
}