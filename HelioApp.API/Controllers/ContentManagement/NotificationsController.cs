using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers;

public sealed class NotificationsController(INotificationService notificationService) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotificationDto>>> GetAll()
    {
        var response = await notificationService.GetAll();
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PushNotificationDto request)
    {
        var response = await notificationService.Create(request);
        return Created();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateNotificationDto request)
    {
        //request = request with { Id = id };
        await notificationService.Update(request);
        return NoContent();
    }
}