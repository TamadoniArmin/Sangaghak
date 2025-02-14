using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Enum;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface ICommentRepository
    {
        #region Create
        public Task<bool> CreateCommentAsync(Comment comment);
        #endregion
        #region Read
        public Task<List<Comment>> GetAllCommentsAsync();
        public Task<List<Comment>> GetCommentByCustomerIdAsync(int CustomerId);
        public Task<List<Comment>> GetCommentByExpertIdAsync(int ExpertId);
        #endregion
        #region Update

        //public Task<bool> UpdateCommentAsync(Comment comment);
        public Task<bool> UpdateCommentStatusAsync(int CommentId, CommentStatusEnum status);
        #endregion
        #region Delete
        public Task<bool> DeleteCommentStatusAsync(int CommentId);
        #endregion
    }
}
