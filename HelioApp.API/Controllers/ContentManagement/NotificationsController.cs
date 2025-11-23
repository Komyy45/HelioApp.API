using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;
using HelioApp.Domain.Exceptions; 
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers;

[Route("api/[controller]")]
[ApiController] 
public sealed class NotificationsController(INotificationService notificationService) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotificationDto>>> GetAll()
    {
        var response = await notificationService.GetAll();
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<NotificationDto>> GetById(Guid id)
    {
        try
        {
            var response = await notificationService.GetById(id);
            return Ok(response); 
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message }); 
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNotificationDto request)
    {
        try
        {
            var id = await notificationService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
        catch (ApplicationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateNotificationDto request)
    {
        try
        {
            var updatedDto = request with { Id = id };
            await notificationService.Update(updatedDto);
            return NoContent(); 
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message }); 
        }
        catch (ApplicationException ex)
        {
            return BadRequest(new { message = ex.Message }); 
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await notificationService.Delete(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message }); 
        }
        catch (ApplicationException ex)
        {
            return BadRequest(new { message = ex.Message }); 
        }
    }
}