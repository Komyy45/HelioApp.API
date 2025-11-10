using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers
{
    [Route("api/Categories/{categoryId:guid}/[controller]")]
    public sealed class SubcategoriesController(ISubcategoryService subcategoryService) : BaseApiController
    { 
        [HttpPost]
        public async Task<IActionResult> AddSubcategory([FromRoute] Guid categoryId, [FromBody] CreateSubcategoryDto dto)
        {
            var request = new CreateSubcategoryDto(categoryId, dto.Name);
            await subcategoryService.CreateAsync(request);
            return Created();
        }
        
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid categoryId, Guid id, [FromBody] UpdateSubcategoryDto request)
        {
            request = request with { Id = id, CategoryId = categoryId };
            await subcategoryService.UpdateAsync(request);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid categoryId, Guid id)
        {
            var ok = await subcategoryService.DeleteAsync(id);
            if (!ok) return BadRequest("Subcategory not found or not empty (has services).");
            return NoContent();
        }
    }
}
