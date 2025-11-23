using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;
using HelioApp.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims; 

namespace HelioApp.API.Controllers
{
    [Route("api/user/notifications")] 
    public sealed class UserNotificationsController(IUserNotificationService userNotificationService) : BaseApiController
    {
        private string GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new ApplicationException("User ID claim not found in token.");
            }
            return userIdClaim.Value;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBriefNotificationDto>>> GetMyNotifications()
        {
            try
            {
                var userId = GetCurrentUserId();
                var response = await userNotificationService.GetNotificationsForUserAsync(userId);
                return Ok(response);
            }
            catch (ApplicationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpGet("unread/count")]
        public async Task<ActionResult<int>> GetUnreadCount()
        {
            var userId = GetCurrentUserId();
            var count = await userNotificationService.GetUnreadCountAsync(userId);
            return Ok(count); 
        }

        [HttpPut("{id:guid}/read")]
        public async Task<IActionResult> MarkAsRead(Guid id)
        {
            try
            {
                var userId = GetCurrentUserId();
                await userNotificationService.MarkAsReadAsync(id, userId);
                return NoContent(); 
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); 
            }
            catch (ApplicationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteNotificationForUser(Guid id)
        {
            try
            {
                var userId = GetCurrentUserId();
                await userNotificationService.DeleteForUserAsync(id, userId);
                return NoContent(); 
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ApplicationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}