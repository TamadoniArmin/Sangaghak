using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Enum;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class CommentRepository : ICommentRepository
    {
        #region Dependency Injection
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        #endregion
        #region Create
        public async Task<bool> CreateCommentAsync(Comment comment)
        {
            var Comment = await _context.Comments.FirstOrDefaultAsync(x => x.Description == comment.Description && x.CustomerId == comment.CustomerId && x.ExpertId == comment.ExpertId);
            if (Comment == null)
            {
                await _context.Comments.AddAsync(comment);
                return true;
            }
            return false;
        }
        #endregion
        #region Read
        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _context.Comments.AsNoTracking().Where( x=>x.IsDeleted == false).ToListAsync();
        }

        public async Task<List<Comment>> GetCommentByCustomerIdAsync(int CustomerId)
        {
            return await _context.Comments.AsNoTracking().Where(x => x.CustomerId == CustomerId && x.IsDeleted == false).ToListAsync();
        }

        public async Task<List<Comment>> GetCommentByExpertIdAsync(int ExpertId)
        {
            return await _context.Comments.AsNoTracking().Where(x => x.ExpertId == ExpertId && x.IsDeleted == false).ToListAsync();
        }
        #endregion
        #region Update
        public async Task<bool> UpdateCommentStatusAsync(int CommentId, CommentStatusEnum status)
        {
            var Comment = await _context.Comments.FirstOrDefaultAsync(x => x.id == CommentId);
            if (Comment != null)
            {
                Comment.Status = status;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteCommentStatusAsync(int CommentId)
        {
            var Comment = await _context.Comments.FirstOrDefaultAsync(x => x.id == CommentId && x.IsDeleted == false);
            if (Comment != null)
            {
                Comment.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
    }
}
