using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Offers;
using HelioApp.Domain.Exceptions; 
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
            try
            {
                var response = await offerCodeService.GetByIdAsync(id);
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOfferCodeDto dto)
        {
            try
            {
                var response = await offerCodeService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOfferCodeDto dto)
        {
            try
            {
                var updated = dto with { Id = id };
                await offerCodeService.UpdateAsync(updated);
                return NoContent(); 
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); 
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleted = await offerCodeService.DeleteAsync(id);
                if (!deleted) return NotFound(); 
                return NoContent();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}