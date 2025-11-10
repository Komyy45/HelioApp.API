using HelioApp.Application.DTOs.Authentication;

namespace HelioApp.Application.Contracts.Services;

public interface IAuthService
{
    public Task<AuthResponse> Login(LoginRequest request);
    public Task<AuthResponse> Register(RegisterRequest request);
    public Task<UserResponse> GetCurrentUserById(string id);
}