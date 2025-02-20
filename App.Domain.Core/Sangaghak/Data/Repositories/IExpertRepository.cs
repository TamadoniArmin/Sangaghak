using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IExpertRepository
    {
        #region Create
        //public Task<bool> RegiterExpertAsync(string Email, string phoneNumber, string Password);
        #endregion
        #region Read
        //public Task<bool> LoginExpertAsync(string Email, string Password);
        public Task<List<Expert>> GetAllExpertsAsync(CancellationToken cancellationToken);
        public Task<Expert> GetExpertByIdAsync(int id, CancellationToken cancellationToken);
        public Task<Expert> GetExpertByNameAsync(string name, CancellationToken cancellationToken);
        public Task<int> GetExpertBalanceAsync(int ExpertId, CancellationToken cancellationToken);
        public Task<int> GetExpertRateAsync(int ExpertId, CancellationToken cancellationToken);
        #endregion
        #region Update
        public Task<bool> SetExpertPointAsync(int CustomerId, int Point, int ExpertId, CancellationToken cancellationToken);
        public Task<bool> IncreaseExpertBalanceAsync(int Money, int ExpertId, CancellationToken cancellationToken);
        public Task<bool> DecreaseExpertBalanceAsync(int Money, int ExpertId, CancellationToken cancellationToken);
        public Task<bool> UpdateExpertInformationAsync(Expert expert, int ExpertId, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteExpertAsync(int ExpertId, CancellationToken cancellationToken);
        #endregion
    }
}
