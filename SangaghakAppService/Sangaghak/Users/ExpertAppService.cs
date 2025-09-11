using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;
using System.Net.Http.Headers;

namespace SangaghakAppService.Sangaghak.Users
{
    public class ExpertAppService : IExpertAppService
    {
        private readonly IExpertService _expertService;
        public ExpertAppService(IExpertService expertService)
        {
            _expertService = expertService;
        }

        public async Task<List<GetSubCategoryNameForExpertsDTO>?> GetExpertSkillsId(int ExpertId, CancellationToken cancellationToken)
        {
            return await _expertService.GetExpertSkillsId(ExpertId, cancellationToken);
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
