using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Community;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers.Community;
[ApiController]
[Route("api/[controller]")]
public sealed class DiscussionCirclesController : BaseApiController
{
    private readonly IDiscussionCircleService service;

    public DiscussionCirclesController(IDiscussionCircleService service)
    {
        this.service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DiscussionCircleDto>>> GetAll()
    {
        var result = await service.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDiscussionCircleDto request)
    {
        var id = await service.Create(request);
        return CreatedAtAction(nameof(GetAll), new { id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDiscussionCircleDto request)
    {
        await service.Update(id, request);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await service.Delete(id);
        return NoContent();
    }
}