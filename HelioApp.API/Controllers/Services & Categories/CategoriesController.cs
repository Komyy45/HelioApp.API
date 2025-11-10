using HelioApp.Application.Contracts;
using HelioApp.Application.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController(ICategoryService categoryService) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await categoryService.GetAllAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            var response = await categoryService.CreateAsync(dto);
            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryDto dto)
        {
            var request = dto with { Id = id };
            await categoryService.UpdateAsync(request);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}

