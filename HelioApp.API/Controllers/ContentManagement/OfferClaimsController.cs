using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Offers;
using HelioApp.Domain.Exceptions; // ⬅️ استيراد الاستثناء من الـ Domain
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
            try
            {
                var response = await offerClaimService.GetByIdAsync(id);
                return Ok(response);
            }
            catch (NotFoundException ex) 
            {
                return NotFound(new { message = ex.Message }); 
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOfferClaimDto dto)
        {
            try
            {
                var response = await offerClaimService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message }); 
            }

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOfferClaimDto dto)
        {
            try
            {
                var updated = dto with { Id = id };
                await offerClaimService.UpdateAsync(updated);
                return NoContent(); 
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); 
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await offerClaimService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound(); 
            }
            return NoContent(); 
        }
    }
}