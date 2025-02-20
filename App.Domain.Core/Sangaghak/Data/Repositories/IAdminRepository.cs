using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IAdminRepository
    {
        #region Read
        public Task<int> GetAdminBalanceAsync(int AdminId, CancellationToken cancellationToken);
        public Task<Admin> GetAdmin(int AdminId, CancellationToken cancellationToken);
        #endregion
        #region Update
        public Task<bool> IncreaseAdminBalanceAsync(int Money, int AdminId, CancellationToken cancellationToken);
        public Task<bool> UpdateAdminInformationAsync(UserBase admin, int AdminId, CancellationToken cancellationToken);
        #endregion
    }
}
