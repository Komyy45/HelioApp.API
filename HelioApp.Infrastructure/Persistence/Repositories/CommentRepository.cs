// using HelioApp.Application.Contracts.Repositories;
// using HelioApp.Domain.Entities.Community;
// using HelioApp.Infrastructure.Persistence.Data;
// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
//
// namespace HelioApp.Infrastructure.Persistence.Repositories
// {
//     public class CommentRepository : ICommentRepository
//     {
//         private readonly HelioAppDbContext _context;
//
//         public CommentRepository(HelioAppDbContext context)
//         {
//             _context = context;
//         }
//
//         public async Task AddAsync(Comment comment)
//         {
//             await _context.Comments.AddAsync(comment);
//         }
//
//         public async Task<Comment?> GetByIdAsync(Guid id)
//         {
//             return await _context.Comments
//                 .Include(c => c.Author)
//                 .Include(c => c.Post)
//                 .FirstOrDefaultAsync(c => c.Id == id);
//         }
//
//         public async Task<IEnumerable<Comment>> GetAllByPostIdAsync(Guid postId)
//         {
//             return await _context.Comments
//                 .Where(c => c.PostId == postId)
//                 .Include(c => c.Author)
//                 .OrderByDescending(c => c.CreatedAt)
//                 .ToListAsync();
//         }
//
//         public async Task DeleteAsync(Comment comment)
//         {
//             _context.Comments.Remove(comment);
//             await Task.CompletedTask;
//         }
//
//         public async Task SaveChangesAsync()
//         {
//             await _context.SaveChangesAsync();
//         }
//     }
//
// }
