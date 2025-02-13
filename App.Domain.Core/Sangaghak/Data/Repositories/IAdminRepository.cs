using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IAdminRepository
    {
        public Task<bool> RegisterAdminAsync(string Email,string PhoneNumber, string Password);
        public Task<bool> LoginAdminAsync(string Email, string Password);
        //public Task<bool> LogoutAdminAsync(string Email, string Password);
        public Task<bool> IncreaseAdminBalanceAsync(int Money, int AdminId);
        public Task<int> GetAdminBalanceAsync(int AdminId);
        public Task<UserBase> GetAdmin(int AdminId);
        //public Task<bool> DecreaseAdminBalanceAsync(int Money, int AdminId);
        public Task<List<UserBase>> GetAllUsersAsync();
        public Task<bool> UpdateAdminInformationAsync(UserBase admin, int AdminId);
    }
}
