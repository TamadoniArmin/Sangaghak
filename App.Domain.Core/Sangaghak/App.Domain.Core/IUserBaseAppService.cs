using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IUserBaseAppService
    {
        public Task<List<UserBase>> GetAllUsersAsync(CancellationToken cancellationToken);
    }
}
