using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.CityServices;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers.CityServices;

public sealed class EmergencyContactsController(IEmergencyContactsService emergencyContactsService) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmergencyContactDto>>> GetAll()
    {
        var response = await emergencyContactsService.GetAll();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmergencyContactDto request)
    {
        var response = await emergencyContactsService.Create(request);
        return Created();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEmergencyContactDto request)
    {
        request = request with { Id = id };
        await emergencyContactsService.Update(request);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await emergencyContactsService.Delete(id);
        return NoContent();
    }
}