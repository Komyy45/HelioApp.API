using HelioApp.Application.Contracts.Authentication.Users_Roles;
using HelioApp.Application.DTOs.Users_Roles.RolesDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers.Authentication
{
    [ApiController]
    [Route("api/admins")]
    public class AdminsController(IAdminService _adminService) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var admins = await _adminService.GetAllAdminsAsync();
            return Ok(admins);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] CreateUpdateAdminRequest dto)
        {
            try
            {
                var admin = await _adminService.AddAdminAsync(dto);
                return CreatedAtAction(nameof(GetAll), new { Id = admin.Id }, admin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string Id, [FromBody] CreateUpdateAdminRequest dto)
        {
            try
            {
                var ok = await _adminService.UpdateAdminAsync(Id, dto);
                if (!ok) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string Id)
        {
            var ok = await _adminService.DeleteAdminAsync(Id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
