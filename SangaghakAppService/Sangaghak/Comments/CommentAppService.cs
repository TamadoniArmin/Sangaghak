using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Comments
{
    public class CommentAppService : ICommentAppService
    {
        #region Dependency Injection
        private readonly ICommentService _commentService;
        private readonly IRequestService _requestService;
        private readonly ICityService _cityService;
        private readonly IUserBaseService _userBaseService;
        private readonly IServicePackageService _servicePackageService;
        private readonly IExpertService _expertService;
        public CommentAppService(ICommentService commentService,
            IRequestService requestService,
            ICityService cityService,
            IUserBaseService userBaseService,
            IServicePackageService servicePackageService,
            IExpertService expertService)
        {
            _commentService = commentService;
            _requestService = requestService;
            _cityService = cityService;
            _userBaseService = userBaseService;
            _servicePackageService = servicePackageService;
            _expertService = expertService;
        }
        #endregion
        #region Create
        public async Task<bool> CreateCommentAsync(CommentForCreateDTO comment, CancellationToken cancellationToken)
        {
            var Result = await _expertService.UpdateExpertRateAsync(comment.ExpertId, comment.CustomerId, comment.Rate, cancellationToken);
            if (!Result)
            {
                return false;
            }
            return await _commentService.CreateCommentAsync(comment, cancellationToken);
        }
        #endregion
        #region Read
        public async Task<List<CommentDTO>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            return await _commentService.GetAllCommentsAsync(cancellationToken);
        }

        public async Task<List<CommentDTO>> GetCommentByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken)
        {
            return await _commentService.GetCommentByCustomerIdAsync(CustomerId, cancellationToken);
        }

        public async Task<List<CommentDTO>> GetCommentByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _commentService.GetCommentByExpertIdAsync(ExpertId, cancellationToken);
        }

        public async Task<List<CommentDTO>> GetPendingCommentAsync(CancellationToken cancellationToken)
        {
            return await _commentService.GetPendingCommentAsync(cancellationToken);
        }

        public async Task<int> GetPendingCommentCountAsync(CancellationToken cancellationToken)
        {
            return await _commentService.GetPendingCommentCountAsync(cancellationToken);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateCommentStatusAsync(int CommentId, CommentStatusEnum status, CancellationToken cancellationToken)
        {
            return await _commentService.UpdateCommentStatusAsync(CommentId, status, cancellationToken);
        }
        #endregion
        #region Delete
        public Task<bool> DeleteCommentStatusAsync(int CommentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}