using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Community;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers.Community;

[Route("api/discussion-circles")]
public sealed class DiscussionCirclesController(IDiscussionCircleService discussionCircleService) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DiscussionCircleDto>>> GetAll()
    {
        var response = await discussionCircleService.GetAll();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDiscussionCircleDto request)
    {
        var response = await discussionCircleService.Create(request);
        return Created();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDiscussionCircleDto request)
    {
        await discussionCircleService.Update(request);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await discussionCircleService.Delete(id);
        return NoContent();
    }
}