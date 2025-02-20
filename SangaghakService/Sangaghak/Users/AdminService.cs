using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.Users
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<UserBase> GetAdmin(int AdminId, CancellationToken cancellationToken)
        {
            return await _adminRepository.GetAdmin(AdminId, cancellationToken);
        }

        public async Task<int> GetAdminBalanceAsync(int AdminId, CancellationToken cancellationToken)
        {
            return await _adminRepository.GetAdminBalanceAsync(AdminId, cancellationToken);
        }

        public async Task<bool> IncreaseAdminBalanceAsync(int Money, int AdminId, CancellationToken cancellationToken)
        {
            return await _adminRepository.IncreaseAdminBalanceAsync(Money, AdminId, cancellationToken);
        }

        public async Task<bool> UpdateAdminInformationAsync(UserBase admin, int AdminId, CancellationToken cancellationToken)
        {
            return await _adminRepository.UpdateAdminInformationAsync(admin, AdminId, cancellationToken);
        }
    }
}
