using App.Domain.Core.Sangaghak.Data.Repositories;
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
        public async Task<bool> DecreaseExpertBalanceAsync(int Money, int ExpertId,CancellationToken cancellationToken)
        {
            return await _expertRepository.DecreaseExpertBalanceAsync(Money, ExpertId,cancellationToken);
        }

        public async Task<bool> DeleteExpertAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _expertRepository.DeleteExpertAsync(ExpertId,cancellationToken);
        }

        public async Task<List<Expert>> GetAllExpertsAsync(CancellationToken cancellationToken)
        {
            return await _expertRepository.GetAllExpertsAsync(cancellationToken);
        }

        public async Task<int> GetExpertBalanceAsync(int ExpertId,CancellationToken cancellationToken)
        {
            return await _expertRepository.GetExpertBalanceAsync(ExpertId, cancellationToken);
        }

        public async Task<Expert> GetExpertByIdAsync(int id,CancellationToken cancellationToken)
        {
            return await _expertRepository.GetExpertByIdAsync(id, cancellationToken);
        }

        public async Task<Expert> GetExpertByNameAsync(string name,CancellationToken cancellationToken)
        {
            return await _expertRepository.GetExpertByNameAsync(name, cancellationToken);
        }

        public async Task<int> GetExpertRateAsync(int ExpertId,CancellationToken cancellationToken)
        {
            return await _expertRepository.GetExpertRateAsync(ExpertId, cancellationToken);
        }

        public async Task<bool> IncreaseExpertBalanceAsync(int Money, int ExpertId,CancellationToken cancellationToken)
        {
            return await _expertRepository.IncreaseExpertBalanceAsync(Money, ExpertId, cancellationToken);
        }

        public async Task<bool> SetExpertPointAsync(int CustomerId, int Point, int ExpertId,CancellationToken cancellationToken)
        {
            return await _expertRepository.SetExpertPointAsync(CustomerId, Point, ExpertId,cancellationToken);
        }

        public async Task<bool> UpdateExpertInformationAsync(Expert expert, int ExpertId,CancellationToken cancellationToken)
        {
            return await _expertRepository.UpdateExpertInformationAsync(expert, ExpertId, cancellationToken);
        }
    }
}
