namespace HelioApp.Application.DTOs.Authentication;

public sealed record RegisterRequest(
    string Email,
    string Password
    );