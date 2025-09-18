using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.Users
{
    public class ExpertService : IExpertService
    {
        private readonly IExpertRepository _expertRepository;
        public ExpertService(IExpertRepository expertRepository)
        {
            _expertRepository = expertRepository;
        }

        public async Task<bool> CheckExpertHasAnySkillAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _expertRepository.CheckExpertHasAnySkillAsync(ExpertId, cancellationToken);
        }

        public async  Task<bool> DeleteExpertAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _expertRepository.DeleteExpertAsync(ExpertId, cancellationToken);
        }

        public async Task<int> GetExpertRateAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _expertRepository.GetExpertRateAsync(ExpertId,cancellationToken);
        }

        public async Task<bool> SetExpertPointAsync(int CustomerId, int Point, int ExpertId, CancellationToken cancellationToken)
        {
            return await _expertRepository.SetExpertPointAsync(CustomerId, Point, ExpertId, cancellationToken);
        }
    }
}
