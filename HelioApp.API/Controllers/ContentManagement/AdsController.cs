using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers;

public sealed class AdsController(IAdService adService) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AdDto>>> GetAll()
    {
        var response = await adService.GetAll();
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateAdDto request)
    {
        var response = await adService.Create(request);
        return Created();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAdDto request)
    {
        await adService.Update(request);
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await adService.Delete(id); 
        return NoContent();
    }
}