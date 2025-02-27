using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Service
{
    public interface IExpertService
    {
        #region Read
        public Task<int> GetExpertRateAsync(int ExpertId, CancellationToken cancellationToken);
        #endregion
        #region Update
        public Task<bool> SetExpertPointAsync(int CustomerId, int Point, int ExpertId, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteExpertAsync(int ExpertId, CancellationToken cancellationToken);
        #endregion
    }
}
