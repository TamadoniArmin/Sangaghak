using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<bool> CreateCommentAsync(Comment comment, CancellationToken cancellationToken)
        {
            return await _commentRepository.CreateCommentAsync(comment, cancellationToken);
        }

        public async Task<bool> DeleteCommentStatusAsync(int CommentId, CancellationToken cancellationToken)
        {
            return await _commentRepository.DeleteCommentStatusAsync(CommentId, cancellationToken);
        }

        public async Task<List<Comment>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            return await _commentRepository.GetAllCommentsAsync(cancellationToken);
        }

        public async Task<List<Comment>> GetCommentByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetCommentByCustomerIdAsync(CustomerId, cancellationToken);
        }

        public async Task<List<Comment>> GetCommentByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetCommentByExpertIdAsync(ExpertId, cancellationToken);
        }

        public async Task<bool> UpdateCommentStatusAsync(int CommentId, CommentStatusEnum status, CancellationToken cancellationToken)
        {
            return await _commentRepository.UpdateCommentStatusAsync(CommentId, status, cancellationToken);
        }
    }
}
