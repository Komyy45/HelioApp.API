using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Offers;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers
{
    [Route("api/[controller]")]
    public class OffersController(IOfferService offerService) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await offerService.GetAllAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOfferDto dto)
        {
            var response = await offerService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = response.Id }, response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOfferDto dto)
        {
            var updatedDto = dto with { Id = id };
            await offerService.UpdateAsync(updatedDto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await offerService.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
