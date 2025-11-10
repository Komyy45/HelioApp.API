using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers;

public sealed class NewsController(INewsService newsService) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NewsDto>>> GetAll()
    {
        var response = await newsService.GetAll();
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateNewsDto request)
    {
        var response = await newsService.Create(request);
        return Created();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateNewsDto request)
    {
        await newsService.Update(request);
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await newsService.Delete(id); 
        return NoContent();
    }
}