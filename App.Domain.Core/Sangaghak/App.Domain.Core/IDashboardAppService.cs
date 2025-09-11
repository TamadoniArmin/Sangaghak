using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IDashboardAppService
    {
        public Task<List<GetUserBaseForViewPage>> GetAllUsersAsync(CancellationToken cancellationToken);
        public Task<int> GetEachRoleCount(RoleEnum role, CancellationToken cancellationToken);
        public Task<int> GetAllUsersCount(CancellationToken cancellationToken);
        public Task<int> GetBalance(int UserId, CancellationToken cancellationToken);
        public Task<List<RequestDTO>> GetAllRequests(CancellationToken cancellationToken);
        public Task<int> GetAllRequestsCountAsync(CancellationToken cancellationToken);
        public Task<int> GetCurrentRequestsCountAsync(CancellationToken cancellationToken);
        public Task<int> GetPendingCommentCountAsync(CancellationToken cancellationToken);
        public Task<int> GetAllPackagesCountAsync(CancellationToken cancellationToken);
    }
}
