using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Reviews;
using Microsoft.AspNetCore.Mvc;

namespace HelioApp.API.Controllers.Reviews;

[Route("api/services/{serviceId:guid}/[controller]")]
public sealed class ReviewsController(IReviewService reviewService) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAll()
    {
        var reviews = await reviewService.GetAll();
        return Ok(reviews);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ReviewDto>> Get([FromRoute] Guid serviceId, [FromRoute] Guid id)
    {
        var review = await reviewService.GetById(serviceId, id);
        return Ok(review);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromRoute] Guid serviceId, [FromBody] CreateReviewDto request)
    {
        request = request with { ServiceId = serviceId };
        var response = await reviewService.Create(request);
        return Created();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid serviceId, [FromRoute] Guid id, [FromBody] UpdateReviewDto request)
    {
        request = request with { ServiceId = serviceId }; 
        await reviewService.Update(request);
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid serviceId, [FromRoute] Guid id)
    {
        await reviewService.Delete(serviceId, id);
        return NoContent();
    }
}