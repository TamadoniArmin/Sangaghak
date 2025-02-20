using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Enum;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface ICommentAppService
    {
        #region Create
        public Task<bool> CreateCommentAsync(Comment comment, CancellationToken cancellationToken);
        #endregion
        #region Read
        public Task<List<Comment>> GetAllCommentsAsync(CancellationToken cancellationToken);
        public Task<List<Comment>> GetCommentByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken);
        public Task<List<Comment>> GetCommentByExpertIdAsync(int ExpertId, CancellationToken cancellationToken);
        #endregion
        #region Update

        public Task<bool> UpdateCommentStatusAsync(int CommentId, CommentStatusEnum status, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteCommentStatusAsync(int CommentId, CancellationToken cancellationToken);
        #endregion
    }
}
