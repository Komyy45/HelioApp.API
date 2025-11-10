using System.Security.Claims;

namespace HelioApp.Application.Contracts.Authentication;

public interface IAuthTokenGenerator
{
    public string GenerateAccessToken(IEnumerable<Claim> claims);
    public string GenerateRefreshToken();
}