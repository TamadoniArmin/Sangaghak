using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Comments
{
    public class CommentAppService : ICommentAppService
    {
        private readonly ICommentService _commentService;
        private readonly IRequestService _requestService;
        private readonly ICityService _cityService;
        private readonly IUserBaseService _userBaseService;
        private readonly IServicePackageService _servicePackageService;
        public CommentAppService(ICommentService commentService, IRequestService requestService, ICityService cityService, IUserBaseService userBaseService, IServicePackageService servicePackageService)
        {
            _commentService = commentService;
            _requestService = requestService;
            _cityService = cityService;
            _userBaseService = userBaseService;
            _servicePackageService = servicePackageService;
        }

        public Task<bool> CreateCommentAsync(CommentForCreateDTO comment, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCommentStatusAsync(int CommentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentDTO>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            var Comments= await _commentService.GetAllCommentsAsync(cancellationToken);
            foreach(var comment in Comments)
            {
                comment.CustomerName = await _userBaseService.GetCustomerNameByCustomerIdAsync(comment.CustomerId, cancellationToken);
                comment.ExpertName=await _userBaseService.GetExpertNameByExpertIdAsync(comment.ExpertId, cancellationToken);
                comment.PackageId=await _requestService.GetRequestPackageIdAsync(comment.RequestId, cancellationToken);
                comment.PackageTiltle=await _servicePackageService.GetPackageTiltleById(comment.PackageId,cancellationToken);
                comment.CityId=await _requestService.GetRequestCityIdAsync(comment.RequestId, cancellationToken);
                comment.CityName=await _cityService.GetNameOfCity(comment.CityId,cancellationToken);
            }
            return Comments;
        }

        public Task<List<CommentDTO>> GetCommentByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentDTO>> GetCommentByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentDTO>> GetPendingCommentAsync(CancellationToken cancellationToken)
        {
            var Comments= await _commentService.GetPendingCommentAsync(cancellationToken);
            foreach (var comment in Comments)
            {
                comment.CustomerName = await _userBaseService.GetCustomerNameByCustomerIdAsync(comment.CustomerId, cancellationToken);
                comment.ExpertName = await _userBaseService.GetExpertNameByExpertIdAsync(comment.ExpertId, cancellationToken);
                comment.PackageId = await _requestService.GetRequestPackageIdAsync(comment.RequestId, cancellationToken);
                comment.PackageTiltle = await _servicePackageService.GetPackageTiltleById(comment.PackageId, cancellationToken);
                comment.CityId = await _requestService.GetRequestCityIdAsync(comment.RequestId, cancellationToken);
                comment.CityName = await _cityService.GetNameOfCity(comment.CityId, cancellationToken);
            }
            return Comments;
        }

        public Task<int> GetPendingCommentCountAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCommentStatusAsync(int CommentId, CommentStatusEnum status, CancellationToken cancellationToken)
        {
            return await _commentService.UpdateCommentStatusAsync(CommentId, status, cancellationToken);
        }
    }
}
