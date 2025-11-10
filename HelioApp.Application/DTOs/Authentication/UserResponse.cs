namespace HelioApp.Application.DTOs.Authentication;

public sealed record UserResponse(
        string Email,
        string Name, 
        string UserName
    );