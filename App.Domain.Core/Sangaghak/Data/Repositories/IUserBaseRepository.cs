using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IUserBaseRepository
    {
        #region Create
        #endregion
        #region Read
        public Task<List<GetUserBaseForViewPage>> GetAllAsync(CancellationToken cancellationToken);
        public Task<GetUserBaseForViewPage> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task<GetUserBaseForViewPage> GetByNameAsync(string name, CancellationToken cancellationToken);
        public Task<UserBaseContactInfoDTO> GetCustomerByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken);
        public Task<string> GetExpertNameByExpertIdAsync(int ExpertId, CancellationToken cancellationToken);
        public Task<UserBaseSummaryDto> GetExpertSummeryByExpertId(int ExpertId, CancellationToken cancellationToken);
        public Task<string> GetCustomerNameByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken);
        public Task<UserBaseSummaryDto> GetCustomerSummeryByCustomerId(int CustomerId, CancellationToken cancellationToken);
        public Task<int> GetCountAsync(CancellationToken cancellationToken);
        public Task<int> GetCountByRoleAsync(RoleEnum role, CancellationToken cancellationToken);
        public Task<int> GetBalanceAsync(int UserId, CancellationToken cancellationToken);
        public Task<int> GetCustomerBalance(int CustomerId, CancellationToken cancellationToken);
        public Task<int> GetCustomerIdByUserId(int UserId, CancellationToken cancellationToken);
        public Task<int> GetExpertIdIdByUserId(int UserId, CancellationToken cancellationToken);
        #endregion
        #region Update
        public Task<bool> IncreaseBalance(int UserId, int money, CancellationToken cancellationToken);
        public Task<bool> DecreaseBalanceAsync(int UserId, int money, CancellationToken cancellationToken);
        public Task<bool> UpdateUserInfo(UserBaseDTO user, int UserId, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteUser(int UserId, CancellationToken cancellationToken);
        #endregion


    }
}
