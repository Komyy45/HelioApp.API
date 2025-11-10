//using AutoMapper;
//using HelioApp.Application.Contracts.Repositories;
//using HelioApp.Application.Contracts.Services;
//using HelioApp.Application.DTOs.Comments;
//using HelioApp.Domain.Entities.Community;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace HelioApp.Application.Services
//{
//    public class CommentService
//    {
//        private readonly ICommentRepository _commentRepository;
//        private readonly IMapper _mapper;

//        public CommentService(ICommentRepository commentRepository, IMapper mapper)
//        {
//            _commentRepository = commentRepository;
//            _mapper = mapper;
//        }

//        public async Task<CommentResponseDto> CreateCommentAsync(CreateCommentRequestDto request, Guid authorId)
//        {
//            var comment = _mapper.Map<Comment>(request);
//            comment.AuthorId = authorId;
//            comment.CreatedAt = DateTimeOffset.UtcNow;

//            await _commentRepository.AddAsync(comment);
//            await _commentRepository.SaveChangesAsync();

//            return _mapper.Map<CommentResponseDto>(comment);
//        }

//        public async Task<IEnumerable<CommentResponseDto>> GetCommentsForPostAsync(Guid postId)
//        {
//            var comments = await _commentRepository.GetAllByPostIdAsync(postId);
//            return _mapper.Map<IEnumerable<CommentResponseDto>>(comments);
//        }

//        public async Task DeleteCommentAsync(Guid commentId)
//        {
//            var comment = await _commentRepository.GetByIdAsync(commentId);
//            if (comment == null)
//                throw new KeyNotFoundException("Comment not found");

//            await _commentRepository.DeleteAsync(comment);
//            await _commentRepository.SaveChangesAsync();
//        }
//    }
//}
