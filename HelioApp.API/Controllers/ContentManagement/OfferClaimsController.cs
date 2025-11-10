using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Offers;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers
{
    [Route("api/[controller]")]
    public class OfferClaimsController(IOfferClaimService offerClaimService) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await offerClaimService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await offerClaimService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOfferClaimDto dto)
        {
            var response = await offerClaimService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOfferClaimDto dto)
        {
            var updated = dto with { Id = id };
            await offerClaimService.UpdateAsync(updated);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await offerClaimService.DeleteAsync(id);
            return NoContent();
        }
    }
}
