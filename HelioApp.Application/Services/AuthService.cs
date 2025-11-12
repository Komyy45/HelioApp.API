using System.Security.Claims;
using HelioApp.Application.Contracts.Authentication;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Authentication;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;

public sealed class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthTokenGenerator _tokenGenerator;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IUserRepository userRepository, IAuthTokenGenerator tokenGenerator, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthResponse> Register(RegisterRequest request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null)
            throw new Exception("Email Already in Use");

        var user = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = request.Email,
            NormalizedEmail = request.Email.ToUpper(),
            UserName = request.Email,
            PhoneNumber = string.Empty,
            PasswordHash = _passwordHasher.HashPassword(request.Password),
            AccountType = AccountType.User,
            Status = AccountStatus.Active,
            CreatedAt = DateTimeOffset.UtcNow
        };

        await _userRepository.AddUserAsync(user);
        await _userRepository.SaveChangesAsync();

        var tokens = GenerateTokens(user);

        return new AuthResponse(tokens.AccessToken, tokens.RefreshToken,
            new UserResponse(user.Email, user.UserName, user.UserName));
    }

    public async Task<AuthResponse> Login(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null || !_passwordHasher.IsCorrectPassword(user.PasswordHash, request.Password))
            throw new Exception("Invalid Email or Password");

        var tokens = GenerateTokens(user);

        return new AuthResponse(tokens.AccessToken, tokens.RefreshToken,
            new UserResponse(user.Email, user.UserName, user.UserName));
    }

    public (string AccessToken, string RefreshToken) GenerateTokens(ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.AccountType.ToString())
        };

        var accessToken = _tokenGenerator.GenerateAccessToken(claims);
        var refreshToken = _tokenGenerator.GenerateRefreshToken();

        return (accessToken, refreshToken);
    }

    public async Task<UserResponse> GetCurrentUserById(string id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new Exception("User Not Found");

        return new UserResponse(user.Email, user.UserName, user.UserName);
    }
}
