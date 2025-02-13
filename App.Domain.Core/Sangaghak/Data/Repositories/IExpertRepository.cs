using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IExpertRepository
    {
        public Task<bool> RegiterExpertAsync(string Email, string phoneNumber, string Password);
        public Task<bool> LoginExpertAsync(string Email, string Password);
        public Task<bool> SetExpertPointAsync(int CustomerId, int Point, int ExpertId);
        public Task<List<Expert>> GetAllExpertsAsync();
        public Task<Expert> GetExpertByIdAsync(int id);
        public Task<Expert> GetExpertByNameAsync(string name);
        public Task<bool> IncreaseExpertBalanceAsync(int Money, int ExpertId);
        public Task<int> GetExpertBalanceAsync(int ExpertId);
        public Task<bool> DecreaseExpertBalanceAsync(int Money, int ExpertId);
        public Task<int> GetExpertRateAsync(int ExpertId);
        public Task<bool> UpdateExpertInformationAsync(Expert expert, int ExpertId);
        public Task<bool> DeleteExpertAsync(int ExpertId);
    }
}
