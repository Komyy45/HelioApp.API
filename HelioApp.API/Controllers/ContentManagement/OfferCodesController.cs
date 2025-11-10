using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Offers;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers
{
    [Route("api/[controller]")]
    public class OfferCodesController(IOfferCodeService offerCodeService) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await offerCodeService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await offerCodeService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOfferCodeDto dto)
        {
            var response = await offerCodeService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOfferCodeDto dto)
        {
            var updated = dto with { Id = id };
            await offerCodeService.UpdateAsync(updated);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await offerCodeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
