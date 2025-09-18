using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IExpertProfileAppService
    {
        public Task<GetUserBaseForViewPage> UserSummary(int UserId, CancellationToken cancellationToken);
        public Task<int> GetUserBalance(int UserId, CancellationToken cancellationToken);
        public Task<int> GetExpertId(int UserId, CancellationToken cancellationToken);
        public Task<bool> CheckExpertHasAnySkillAsync(int ExpertId, CancellationToken cancellationToken);
        public Task<List<CommentDTO>> GetCommentByExpertIdAsync(int ExpertId, CancellationToken cancellationToken);
        public Task<List<RequestDTO>> GetExpertNotCompeletedRequestsAsync(int ExpertId, CancellationToken cancellationToken);
        public Task<List<GetSubCategoryNameForExpertsDTO>> GetExpertSkillsNameByExpertId(int ExpertId, CancellationToken cancellationToken);
        public Task<List<CommentDTO>?> GetExpertCommentsAsync(int ExpertId, CancellationToken cancellationToken);
        public Task<int> GetExpertRateAysnc(int ExpertId, CancellationToken cancellationToken);
        public Task<int> GetMatchRequestCountForExpertAsync(int ExpertId, int CityId, CancellationToken cancellationToken);
        public Task<int> GetAllExpertRequestsCountAsync(int ExpertId, CancellationToken cancellationToken);
        public Task<List<RequestDTO>> GetNotCompeletedExpertRequests(int ExpertId, CancellationToken cancellationToken);
        public Task<int> GetAllExpertOffersCount(int expertId, CancellationToken cancellationToken);
    }
}
