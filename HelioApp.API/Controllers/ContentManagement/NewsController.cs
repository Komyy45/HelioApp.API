using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class NewsController : BaseApiController
{
    private readonly INewsService newsService;

    public NewsController(INewsService newsService)
    {
        this.newsService = newsService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NewsDto>>> GetAll()
    {
        var response = await newsService.GetAll();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNewsDto request)
    {
        var id = await newsService.Create(request);
        return CreatedAtAction(nameof(GetAll), new { id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateNewsDto request)
    {
        await newsService.Update(id, request);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await newsService.Delete(id);
        return NoContent();
    }
}