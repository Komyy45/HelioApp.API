using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AdsController(IAdService adService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AdDto>>> GetAll()
    {
        var result = await adService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAdDto request)
    {
        var id = await adService.Create(request);

        return CreatedAtAction(
            nameof(GetAll),
            new { id },
            null
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAdDto request)
    {
        request = request with { Id = id };

        await adService.Update(request);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await adService.Delete(id);
        return NoContent();
    }
}