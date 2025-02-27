using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Entities.Users;
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
        public async Task<bool> CreateCommentAsync(CommentForCreateDTO comment, CancellationToken cancellationToken)
        {
            try
            {
                var Comment = new Comment()
                {
                    Description = comment.Description,
                    Rate = comment.Rate,
                    ExpertId = comment.ExpertId,
                    RequestId = comment.RequestId,
                    CustomerId = comment.CustomerId,
                    SetAt = DateTime.Now,
                    Status = CommentStatusEnum.Pending
                };
                await _context.Comments.AddAsync(Comment, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception("Exception");
            }
        }
        #endregion
        #region Read
        public async Task<List<CommentDTO>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            return await _context.Comments
                .Include(x => x.Request)
                .AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .Select(x => new CommentDTO()
                {
                    Id = x.id,
                    Description = x.Description,
                    Rate = x.Rate,
                    ExpertId = x.ExpertId,
                    RequestId = x.RequestId,
                    CustomerId = x.CustomerId
                }
                ).ToListAsync(cancellationToken);
        }

        public async Task<List<CommentDTO>> GetCommentByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken)
        {
            return await _context.Comments
                .Include(x => x.Request)
                .AsNoTracking()
                .Where(x => x.CustomerId == CustomerId && x.IsDeleted == false)
                .Select(x => new CommentDTO()
                {
                    Id = x.id,
                    Description = x.Description,
                    Rate = x.Rate,
                    ExpertId = x.ExpertId,
                    RequestId = x.RequestId,
                    CustomerId = x.CustomerId,
                    JobCategory=x.Request.Category.Title,
                }
                ).ToListAsync(cancellationToken);
        }

        public async Task<List<CommentDTO>> GetCommentByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _context.Comments
                .Include(x => x.Request)
                .AsNoTracking()
                .Where(x => x.ExpertId == ExpertId && x.IsDeleted == false)
                .Select(x => new CommentDTO()
                {
                    Id = x.id,
                    Description = x.Description,
                    Rate = x.Rate,
                    ExpertId = x.ExpertId,
                    RequestId = x.RequestId,
                    CustomerId = x.CustomerId,
                    JobCategory = x.Request.Category.Title,
                }
                ).ToListAsync(cancellationToken);
        }
        public async Task<List<CommentDTO>> GetPendingCommentAsync(CancellationToken cancellationToken)
        {
            return await _context.Comments
            .Include(x => x.Request)
            .AsNoTracking()
            .Where(x => x.Status == CommentStatusEnum.Pending && x.IsDeleted == false)
            .Select(x => new CommentDTO()
            {
                Id = x.id,
                Description = x.Description,
                Rate = x.Rate,
                ExpertId = x.ExpertId,
                RequestId = x.RequestId,
                CustomerId = x.CustomerId,
                JobCategory = x.Request.Category.Title,
            }
            ).ToListAsync(cancellationToken);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateCommentStatusAsync(int CommentId, CommentStatusEnum status, CancellationToken cancellationToken)
        {
            var Comment = await _context.Comments.FirstOrDefaultAsync(x => x.id == CommentId, cancellationToken);
            if (Comment != null)
            {
                Comment.Status = status;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteCommentStatusAsync(int CommentId, CancellationToken cancellationToken)
        {
            var Comment = await _context.Comments.FirstOrDefaultAsync(x => x.id == CommentId && x.IsDeleted == false, cancellationToken);
            if (Comment != null)
            {
                Comment.IsDeleted = true;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<int> GetPendingCommentCountAsync(CancellationToken cancellationToken)
        {
            return await _context.Comments.Where(x=>x.Status == CommentStatusEnum.Pending && x.IsDeleted==false).CountAsync(cancellationToken);
        }
        #endregion
    }
}
