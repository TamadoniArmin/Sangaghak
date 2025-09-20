using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.Users
{
    public class UserBaseService : IUserBaseService
    {
        private readonly IUserBaseRepository _repository;
        public UserBaseService(IUserBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DecreaseBalanceAsync(int UserId, int money, CancellationToken cancellationToken)
        {
            return await _repository.DecreaseBalanceAsync(UserId, money, cancellationToken);
        }

        public async Task<bool> DeleteUser(int UserId, CancellationToken cancellationToken)
        {
            return await _repository.DeleteUser(UserId, cancellationToken);
        }

        public async Task<UserBasicInfoDTO?> GetAdminBasicInfoByAdminIdAsync(int adminId, CancellationToken cancellationToken)
        {
            return await _repository.GetAdminBasicInfoByAdminIdAsync(adminId, cancellationToken);
        }

        public async Task<List<GetUserBaseForViewPage>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }

        public async Task<int> GetBalanceAsync(int UserId, CancellationToken cancellationToken)
        {
            return await _repository.GetBalanceAsync(UserId, cancellationToken);
        }

        public async Task<GetUserBaseForViewPage> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }

        public async  Task<GetUserBaseForViewPage> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _repository.GetByNameAsync(name, cancellationToken);
        }

        public async  Task<int> GetCountAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetCountAsync(cancellationToken);
        }

        public async Task<int> GetCountByRoleAsync(RoleEnum role, CancellationToken cancellationToken)
        {
            return await _repository.GetCountByRoleAsync(role, cancellationToken);
        }

        public Task<int> GetCustomerBalance(int CustomerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<UserBasicInfoDTO?> GetCustomerBasicInfoByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
        {
            return await _repository.GetCustomerBasicInfoByCustomerIdAsync(customerId, cancellationToken);
        }

        public async Task<UserBaseContactInfoDTO> GetCustomerByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken)
        {
            return await _repository.GetCustomerByCustomerIdAsync(CustomerId, cancellationToken);
        }

        public async Task<int> GetCustomerIdByUserId(int UserId, CancellationToken cancellationToken)
        {
            return await _repository.GetCustomerIdByUserId(UserId, cancellationToken);
        }

        public async Task<string> GetCustomerNameByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken)
        {
            return await _repository.GetCustomerNameByCustomerIdAsync(CustomerId,cancellationToken);
        }

        public async Task<UserBaseSummaryDto> GetCustomerSummeryByCustomerId(int CustomerId, CancellationToken cancellationToken)
        {
            return await _repository.GetCustomerSummeryByCustomerId(CustomerId, cancellationToken);
        }

        public async Task<UserBasicInfoDTO?> GetExpertBasicInfoByExpertIdAsync(int expertId, CancellationToken cancellationToken)
        {
            return await _repository.GetExpertBasicInfoByExpertIdAsync(expertId, cancellationToken);
        }

        public async Task<int> GetExpertIdIdByUserId(int UserId, CancellationToken cancellationToken)
        {
            return await _repository.GetExpertIdIdByUserId(UserId,cancellationToken);
        }

        public async Task<string> GetExpertNameByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _repository.GetExpertNameByExpertIdAsync(ExpertId, cancellationToken);
        }

        public async Task<UserBaseSummaryDto> GetExpertSummeryByExpertId(int ExpertId, CancellationToken cancellationToken)
        {
            return await _repository.GetExpertSummeryByExpertId(ExpertId,cancellationToken) ;
        }

        public async Task<bool> IncreaseBalance(int UserId, int money, CancellationToken cancellationToken)
        {
            return await _repository.IncreaseBalance(UserId, money, cancellationToken);
        }

        public async Task<bool> UpdateUserInfoAsync(UserBaseDTO user, int UserId, CancellationToken cancellationToken)
        {
            return await _repository.UpdateUserInfo(user, UserId, cancellationToken);
        }
    }
}
