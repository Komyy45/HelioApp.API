using HelioApp.Application.Contracts.Authentication.Users_Roles;
using HelioApp.Application.DTOs.Authentication;
using HelioApp.Application.DTOs.Users_Roles;
using HelioApp.Application.DTOs.Users_Roles.UsersDTO;
using HelioApp.Application.Services.Users_Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UsersController(IUserService _userService) : ControllerBase
{

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpPut("{Id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(string Id, [FromBody] UpdateUserRequest request)
    {
        var ok = await _userService.UpdateUserAsync(Id, request);
        if (!ok) return NotFound();
        return NoContent();
    }

   
    [HttpDelete("all")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> BulkDelete()
    {
        await _userService.DeleteAllUsersAsync();
        return NoContent();
    }
}
