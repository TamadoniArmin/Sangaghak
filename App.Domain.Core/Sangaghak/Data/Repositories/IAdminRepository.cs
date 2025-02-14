using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IAdminRepository
    {
        #region Create
        public Task<bool> RegisterAdminAsync(string Email,string PhoneNumber, string Password);
        #endregion
        #region Read
        public Task<bool> LoginAdminAsync(string Email, string Password);
        public Task<List<UserBase>> GetAllUsersAsync();
        public Task<int> GetAdminBalanceAsync(int AdminId);
        public Task<UserBase> GetAdmin(int AdminId);
        #endregion
        #region Update
        //public Task<bool> LogoutAdminAsync(string Email, string Password);
        public Task<bool> IncreaseAdminBalanceAsync(int Money, int AdminId);
        //public Task<bool> DecreaseAdminBalanceAsync(int Money, int AdminId);
        public Task<bool> UpdateAdminInformationAsync(UserBase admin, int AdminId);
        #endregion
    }
}
