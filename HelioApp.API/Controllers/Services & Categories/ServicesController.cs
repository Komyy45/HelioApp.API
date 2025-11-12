using HelioApp.Application.Contracts;
using HelioApp.Application.DTOS;
using HelioApp.Application.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController(IServiceService serviceService) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Guid subcategoryId, [FromQuery] PaginationRequest request)
        {
            var response = await serviceService.GetAllAsync(subcategoryId, request);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await serviceService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateServiceDto request)
        {
            var response = await serviceService.CreateAsync(request);
            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateServiceDto request)
        {
            request = request with { Id = id };
            await serviceService.UpdateAsync(request);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await serviceService.DeleteAsync(id);
            return NoContent();
        }

        // [HttpPatch("{id:guid}/toggle-favorite")]
        // public async Task<IActionResult> ToggleFavorite(Guid id)
        // {
        //     var s = await serviceService.ToggleFavoriteAsync(id);
        //     if (s == null) return NotFound();
        //     return Ok(new { s.Id, s.IsFavorite });
        // }
    }
}
