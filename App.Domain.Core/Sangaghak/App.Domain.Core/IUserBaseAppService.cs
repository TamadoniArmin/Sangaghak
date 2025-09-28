using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IUserBaseAppService
    {
        #region Create
        public Task<IdentityResult> Register(UserForRegisterDTO model, CancellationToken cancellationToken);
        #endregion
        #region Read
        public Task<IdentityResult> Login(string username, string password, bool rememberMe);
        Task<List<GetUserBaseForViewPage>> GetAllUsersAsync(CancellationToken cancellationToken);
        public Task<UserBasicInfoDTO?> GetExpertBasicInfoByExpertIdAsync(int expertId, CancellationToken cancellationToken);
        Task<int> GetBalance(int UserId, CancellationToken cancellationToken);
        Task<int> GetEachRoleCount(RoleEnum customer, CancellationToken cancellationToken);
        public Task<GetUserBaseForViewPage> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task<int> GetCustomerIdByUserId(int UserId, CancellationToken cancellationToken);
        public Task<int> GetExpertIdIdByUserId(int UserId, CancellationToken cancellationToken);
        public Task<UserDTO> GetCurrentUserAsync();
        public Task<UserDTO> GetByIdAsync(int userId);
        #endregion
        #region Update
        public Task<IdentityResult> UpdateUserInfo(UserBaseDTO userDto, int userId, CancellationToken cancellationToken);
        public Task LogoutAsync();
        #endregion
        #region Delete
        public Task<IdentityResult> DeleteUser(int UserId, CancellationToken cancellationToken);
        #endregion
    }
}
