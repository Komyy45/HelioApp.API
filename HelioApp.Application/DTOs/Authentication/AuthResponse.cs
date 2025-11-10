namespace HelioApp.Application.DTOs.Authentication;

public sealed record AuthResponse(
    string AccessToken,
    string RefreshToken,
    UserResponse User
    );