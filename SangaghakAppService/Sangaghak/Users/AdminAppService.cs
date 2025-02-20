using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Users
{
    public class AdminAppService : IAdminAppService
    {
        private readonly IAdminService _adminService;
        public AdminAppService(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<UserBase> GetAdmin(int AdminId, CancellationToken cancellationToken)
        {
            return await _adminService.GetAdmin(AdminId, cancellationToken);
        }

        public async Task<int> GetAdminBalanceAsync(int AdminId, CancellationToken cancellationToken)
        {
            return await _adminService.GetAdminBalanceAsync(AdminId, cancellationToken);
        }

        public async Task<bool> IncreaseAdminBalanceAsync(int Money, int AdminId, CancellationToken cancellationToken)
        {
            return await _adminService.IncreaseAdminBalanceAsync(Money, AdminId, cancellationToken);
        }

        public async Task<bool> UpdateAdminInformationAsync(UserBase admin, int AdminId, CancellationToken cancellationToken)
        {
            return await _adminService.UpdateAdminInformationAsync(admin, AdminId, cancellationToken);
        }
    }
}
