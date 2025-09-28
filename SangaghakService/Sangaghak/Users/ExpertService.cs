using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.Users
{
    public class ExpertService : IExpertService
    {
        #region Dependency Injection
        private readonly IExpertRepository _expertRepository;
        public ExpertService(IExpertRepository expertRepository)
        {
            _expertRepository = expertRepository;
        }
        #endregion
        #region Create
        #endregion
        #region Read
        public async Task<bool> CheckExpertHasAnySkillAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _expertRepository.CheckExpertHasAnySkillAsync(ExpertId, cancellationToken);
        }
        public async Task<int> GetExpertRateAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _expertRepository.GetExpertRateAsync(ExpertId, cancellationToken);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateExpertRateAsync(int expertId, int pointerId, int rate, CancellationToken cancellationToken)
        {
            return await _expertRepository.UpdateExpertRateAsync(expertId, pointerId, rate, cancellationToken);
        }

        public async Task<bool> UpdateExpertSkillsAsync(int expertId, List<Category> newSkillIds, CancellationToken cancellationToken)
        {
            return await _expertRepository.UpdateExpertSkillsAsync(expertId, newSkillIds, cancellationToken);
        }
        public async Task<bool> SetExpertPointAsync(int CustomerId, int Point, int ExpertId, CancellationToken cancellationToken)
        {
            return await _expertRepository.SetExpertPointAsync(CustomerId, Point, ExpertId, cancellationToken);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteExpertAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _expertRepository.DeleteExpertAsync(ExpertId, cancellationToken);
        }
        #endregion
    }
}
