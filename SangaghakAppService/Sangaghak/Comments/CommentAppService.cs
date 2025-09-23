using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Entities.Users;
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

        public async Task<bool> CreateCommentAsync(CommentForCreateDTO comment, CancellationToken cancellationToken)
        {
            var Result = await _expertService.UpdateExpertRateAsync(comment.ExpertId, comment.CustomerId, comment.Rate, cancellationToken);
            if (!Result)
            {
                return false;
            }
            return await _commentService.CreateCommentAsync(comment, cancellationToken);
        }

        public Task<bool> DeleteCommentStatusAsync(int CommentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentDTO>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            var Comments= await _commentService.GetAllCommentsAsync(cancellationToken);
            if (Comments != null)
            {
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
            return null;
        }

        public async Task<List<CommentDTO>> GetCommentByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken)
        {
            var Comments= await _commentService.GetCommentByCustomerIdAsync(CustomerId, cancellationToken);
            if (Comments != null)
            {
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
            return null;
        }

        public async Task<List<CommentDTO>> GetCommentByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            var Comments = await _commentService.GetCommentByExpertIdAsync(ExpertId, cancellationToken);
            if (Comments != null)
            {
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
            return null;
        }

        public async Task<List<CommentDTO>> GetPendingCommentAsync(CancellationToken cancellationToken)
        {
            var Comments= await _commentService.GetPendingCommentAsync(cancellationToken);
            if (Comments != null)
            {
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
            return null;
        }

        public async Task<int> GetPendingCommentCountAsync(CancellationToken cancellationToken)
        {
            return await _commentService.GetPendingCommentCountAsync(cancellationToken);
        }

        public async Task<bool> UpdateCommentStatusAsync(int CommentId, CommentStatusEnum status, CancellationToken cancellationToken)
        {
            return await _commentService.UpdateCommentStatusAsync(CommentId, status, cancellationToken);
        }
    }
}
