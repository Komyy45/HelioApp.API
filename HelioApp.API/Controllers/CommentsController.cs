//using Microsoft.AspNetCore.Mvc;

//namespace HelioApp.API.Controllers
//{
//    using global::HelioApp.Application.Contracts.Services;
//    using global::HelioApp.Application.DTOs.Comments;
//    using Microsoft.AspNetCore.Authorization;
//    using Microsoft.AspNetCore.Mvc;

//    namespace HelioApp.API.Controllers;

//    [ApiController]
//    [Route("api/[controller]")]
//    public class CommentsController : ControllerBase
//    {
//        private readonly ICommentService _commentService;

//        public CommentsController(ICommentService commentService)
//        {
//            _commentService = commentService;
//        }

//        [HttpPost]
//        [Authorize]
//        public async Task<IActionResult> CreateComment([FromBody] CreateCommentRequest request)
//        {
//            var authorId = Guid.Parse(User.FindFirst("uid")!.Value);
//            var result = await _commentService.CreateCommentAsync(authorId, request);
//            return Ok(result);
//        }

//        [HttpGet("post/{postId}")]
//        public async Task<IActionResult> GetCommentsByPost(Guid postId)
//        {
//            var comments = await _commentService.GetCommentsByPostAsync(postId);
//            return Ok(comments);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetCommentById(Guid id)
//        {
//            var comment = await _commentService.GetCommentByIdAsync(id);
//            if (comment == null) return NotFound();
//            return Ok(comment);
//        }

//        [HttpDelete("{id}")]
//        [Authorize]
//        public async Task<IActionResult> DeleteComment(Guid id)
//        {
//            var authorId = Guid.Parse(User.FindFirst("uid")!.Value);
//            var deleted = await _commentService.DeleteCommentAsync(id, authorId);
//            return deleted ? NoContent() : NotFound();
//        }

//        [HttpPost("{id}/like")]
//        public async Task<IActionResult> LikeComment(Guid id)
//        {
//            var liked = await _commentService.LikeCommentAsync(id);
//            return liked ? Ok() : NotFound();
//        }

//        [HttpPost("{id}/report")]
//        public async Task<IActionResult> ReportComment(Guid id)
//        {
//            var reported = await _commentService.ReportCommentAsync(id);
//            return reported ? Ok() : NotFound();
//        }
//    }

//}
