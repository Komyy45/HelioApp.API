using System.Security.Claims;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers.Authentication;

public sealed class AuthController(IAuthService authService) : BaseApiController
{
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(LoginRequest request)
    {
        var response = await authService.Login(request);
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register(RegisterRequest request)
    {
        var response = await authService.Register(request);
        return Ok(response);
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<UserResponse>> GetCurrentUserProfile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        if (userId is null) return Unauthorized("The Id value is missing!");
        
        var response = await authService.GetCurrentUserById(userId); 
        
        return Ok();
    }
}