using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Comments
{
    public class CommentAppService : ICommentAppService
    {
        private readonly ICommentService _commentService;
        public CommentAppService(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<bool> CreateCommentAsync(Comment comment, CancellationToken cancellationToken)
        {
            return await _commentService.CreateCommentAsync(comment, cancellationToken);
        }

        public async Task<bool> DeleteCommentStatusAsync(int CommentId, CancellationToken cancellationToken)
        {
            return await _commentService.DeleteCommentStatusAsync(CommentId, cancellationToken);
        }

        public async Task<List<Comment>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            return await _commentService.GetAllCommentsAsync(cancellationToken);
        }

        public async Task<List<Comment>> GetCommentByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken)
        {
            return await _commentService.GetCommentByCustomerIdAsync(CustomerId, cancellationToken);
        }

        public async Task<List<Comment>> GetCommentByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _commentService.GetCommentByExpertIdAsync(ExpertId, cancellationToken);
        }

        public async Task<bool> UpdateCommentStatusAsync(int CommentId, CommentStatusEnum status, CancellationToken cancellationToken)
        {
            return await _commentService.UpdateCommentStatusAsync(CommentId, status, cancellationToken);
        }
    }
}
