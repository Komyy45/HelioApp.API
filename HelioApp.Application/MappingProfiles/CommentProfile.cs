// using AutoMapper;
// using HelioApp.Domain.Entities.Community;
// using HelioApp.Application.DTOs.Comments;
// namespace HelioApp.Application.Mappings;
//
// public class CommentProfile : Profile
// {
//         public CommentProfile()
//         {
//             CreateMap<CreateCommentRequestDto, Comment>();
//             CreateMap<Comment, CommentResponseDto>()
//                 .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.UserName));
//         }
// }
