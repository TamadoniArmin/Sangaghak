using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IUserBaseAppService
    {
        public Task<IdentityResult> Register(UserForRegisterDTO model, CancellationToken cancellationToken);
        public Task<IdentityResult> Login(string username, string password, bool rememberMe);
        Task<List<GetUserBaseForViewPage>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<int> GetBalance(int UserId, CancellationToken cancellationToken);
        Task<int> GetEachRoleCount(RoleEnum customer, CancellationToken cancellationToken);
        public Task<GetUserBaseForViewPage> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task<bool> UpdateUserInfoAsync(UserBaseDTO user, int UserId, CancellationToken cancellationToken);
    }
}
