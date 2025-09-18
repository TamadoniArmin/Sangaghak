using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SangaghakAppService.Sangaghak.Pages
{
    public class ExpertProfileAppService : IExpertProfileAppService
    {
        private readonly IUserBaseService _userBaseService;
        private readonly IRequestService _requestService;
        private readonly IServicePackageService _servicePackageService;
        private readonly ICityService _cityService;
        private readonly ICommentService _commentService;
        private readonly IExpertService _expertService;
        private readonly IOfferService _offerService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<UserBase> _userManager;
        public ExpertProfileAppService(IUserBaseService userBaseService, 
            IRequestService requestService,
            IServicePackageService servicePackageService, 
            ICommentService commentService,
            IExpertService expertService,
            IOfferService offerService,
            ICityService cityService, 
            ICategoryService categoryService,
            UserManager<UserBase> userManager)
        {
            _userBaseService = userBaseService;
            _requestService = requestService;
            _servicePackageService = servicePackageService;
            _cityService = cityService;
            _userManager = userManager;
            _commentService= commentService;
            _expertService = expertService;
            _offerService = offerService;
            _categoryService = categoryService;
        }
        public async Task<GetUserBaseForViewPage> UserSummary(int UserId, CancellationToken cancellationToken)
        {
            var wantedUser= await _userBaseService.GetByIdAsync(UserId, cancellationToken);
            wantedUser.FullName= wantedUser.FirstName+" "+ wantedUser.LastName;
            wantedUser.CityName = await _cityService.GetNameOfCity(wantedUser.CityId, cancellationToken);
            return wantedUser;
        }
        public async Task<int> GetUserBalance(int UserId, CancellationToken cancellationToken)
        {
            var User = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == UserId && x.IsDeleted == false);
            if (User == null) return 0;
            return User.Balance;
        }
        public async Task<int> GetExpertId(int UserId, CancellationToken cancellationToken)
        {
            var User = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == UserId && x.IsDeleted == false);
            if (User == null) return 0;
            return User.ExpertId.Value;
        }
        public async Task<bool> CheckExpertHasAnySkillAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _expertService.CheckExpertHasAnySkillAsync(ExpertId, cancellationToken);
        }
        public async Task<List<CommentDTO>> GetCommentByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _commentService.GetCommentByExpertIdAsync(ExpertId,cancellationToken);
        }
        public async Task<List<RequestDTO>> GetExpertNotCompeletedRequestsAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _requestService.GetExpertNotCompeletedRequestsAsync(ExpertId, cancellationToken);
        }
        public async Task<List<GetSubCategoryNameForExpertsDTO>> GetExpertSkillsNameByExpertId(int ExpertId, CancellationToken cancellationToken)
        {
            return await _categoryService.GetCategoryNamesByExpertId(ExpertId, cancellationToken);
        }
        public async Task<int> GetMatchRequestCountForExpertAsync(int ExpertId, int CityId, CancellationToken cancellationToken)
        {
            var checkExpertHasSkill = await _expertService.CheckExpertHasAnySkillAsync(ExpertId, cancellationToken);
            if (!checkExpertHasSkill)
            {
                return 0;
            }
            else
            {
                List<int> expertSkillsId = await _categoryService.GetCategoryIdByExpertId(ExpertId, cancellationToken);
                if (!expertSkillsId.Any())
                {
                    return 0;
                }
                else
                {
                    List<int> matchPackages = await _servicePackageService.GetCategoryPackagesIdbyCategoriesIdAsync(expertSkillsId, cancellationToken);
                    if (!matchPackages.Any())
                    {
                        return 0;
                    }
                    else
                    {
                        return await _requestService.GetMatchRequestForExpertCount(CityId, expertSkillsId, cancellationToken);
                    }
                }
            }
        }
        public async Task<List<RequestDTO>> GetNotCompeletedExpertRequests(int ExpertId, CancellationToken cancellationToken)
        {
            return await _requestService.GetExpertNotCompeletedRequestsAsync(ExpertId, cancellationToken);
        }
        public async Task<int> GetAllExpertRequestsCountAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _requestService.GetAllExpertRequestsCountAsync(ExpertId, cancellationToken);
        }
        public async Task<List<CommentDTO>?> GetExpertCommentsAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _commentService.GetCommentByExpertIdAsync(ExpertId, cancellationToken);
        }
        public async Task<int> GetExpertRateAysnc(int ExpertId, CancellationToken cancellationToken)
        {
           return await _expertService.GetExpertRateAsync(ExpertId, cancellationToken);
        }

        public async Task<int> GetAllExpertOffersCount(int expertId, CancellationToken cancellationToken)
        {
            return await _offerService.GetAllExpertOffersCount(expertId, cancellationToken);
        }
    }
}
