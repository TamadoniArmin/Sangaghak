using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.IdentityModel.Tokens;
using SangaghakService.Sangaghak.BaseEntities;
using SangaghakService.Sangaghak.Categories;
using SangaghakService.Sangaghak.Requests;
using SangaghakService.Sangaghak.Users;
using System.Net.Http.Headers;

namespace SangaghakAppService.Sangaghak.Users
{
    public class ExpertAppService : IExpertAppService
    {
        private readonly IExpertService _expertService;
        private readonly ICategoryService _categoryService;
        private readonly IRequestService _requestService;
        private readonly IServicePackageService _packageService;
        private readonly IUserBaseService _userBaseService;
        private readonly ICityService _cityService;
        public ExpertAppService(IExpertService expertService, 
            ICategoryService categoryService, 
            IRequestService requestService,
            IServicePackageService servicePackageService,
            IUserBaseService userBaseService,
            ICityService cityService)
        {
            _expertService = expertService;
            _categoryService = categoryService;
            _requestService = requestService;
            _packageService = servicePackageService;
            _userBaseService = userBaseService;
            _cityService = cityService;
        }

        public async Task<bool> CheckExpertHasAnySkillAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _expertService.CheckExpertHasAnySkillAsync(ExpertId, cancellationToken);
        }
        public async Task<List<RequestDTO>?> GetMathRequestForExpertInfo(int ExpertId, int CityId, CancellationToken cancellationToken)
        {
            var checkExpertHasSkill = await _expertService.CheckExpertHasAnySkillAsync(ExpertId, cancellationToken);
            if (!checkExpertHasSkill)
            {
                return null;
            }
            else
            {
                List<int> expertSkillsId = await _categoryService.GetCategoryIdByExpertId(ExpertId, cancellationToken);
                if (!expertSkillsId.Any())
                {
                    return null;
                }
                else
                {
                    List<int> matchPackages= await _packageService.GetCategoryPackagesIdbyCategoriesIdAsync(expertSkillsId, cancellationToken);
                    if (!matchPackages.Any())
                    {
                        return null;
                    }
                    else
                    {
                        var matchRequests = await _requestService.GetMatchRequestForExpert(CityId, expertSkillsId, cancellationToken);
                        if (!matchRequests.Any())
                        {
                            return null;
                        }
                        else
                        {
                            return matchRequests;
                        }
                    }

                }
            }

        }

        public async Task<bool> UpdateExpertSkillsAsync(int expertId, List<int> newSkillIds, CancellationToken cancellationToken)
        {
            var ExpertSkills= await _categoryService.GetSubCategoriesForExpertSkillsAsync(newSkillIds, cancellationToken);
            if (!ExpertSkills.IsNullOrEmpty())
            {
                return await _expertService.UpdateExpertSkillsAsync(expertId,ExpertSkills, cancellationToken);
            }
            return false;
        }

        public async Task<GetUserBaseForViewPage> UserSummary(int UserId, CancellationToken cancellationToken)
        {
            var wantedUser = await _userBaseService.GetByIdAsync(UserId, cancellationToken);
            wantedUser.FullName = wantedUser.FirstName + " " + wantedUser.LastName;
            wantedUser.CityName = await _cityService.GetNameOfCity(wantedUser.CityId, cancellationToken);
            return wantedUser;
        }
        //public Task<bool> DecreaseExpertBalanceAsync(int Money, int ExpertId, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> DeleteExpertAsync(int ExpertId, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<List<Expert>> GetAllExpertsAsync(CancellationToken cancellationToken)
        //{
        //    return await _expertService.GetAllExpertsAsync(cancellationToken);
        //}

        //public Task<int> GetExpertBalanceAsync(int ExpertId, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Expert> GetExpertByIdAsync(int id, CancellationToken cancellationToken)
        //{
        //    return await _expertService.GetExpertByIdAsync(id, cancellationToken);
        //}

        //public async Task<Expert> GetExpertByNameAsync(string name, CancellationToken cancellationToken)
        //{
        //    return await _expertService.GetExpertByNameAsync(name, cancellationToken);
        //}

        //public async Task<int> GetExpertRateAsync(int ExpertId, CancellationToken cancellationToken)
        //{
        //    return await _expertService.GetExpertRateAsync(ExpertId, cancellationToken);
        //}

        //public Task<bool> IncreaseExpertBalanceAsync(int Money, int ExpertId, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> SetExpertPointAsync(int CustomerId, int Point, int ExpertId, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> UpdateExpertInformationAsync(Expert expert, int ExpertId, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
