using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOS.Properties;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers;


public sealed class PropertiesController(IPropertyService propertyService) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PropertyDto>>> GetAll()
    {
        var response = await propertyService.GetAll();
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PropertyDetailsDto>> Get([FromRoute] Guid id)
    {
        var response = await propertyService.GetById(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreatedPropertyDto request)
    {
        var response = await propertyService.Create(request);
        return CreatedAtAction(nameof(Get), new { id = response }, new { response });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatedPropertyDto request)
    {
        // request = request with { Id = id };
        await propertyService.Update(request);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await propertyService.Delete(id);
        return NoContent();
    }
}
