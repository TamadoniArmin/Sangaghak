using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Service
{
    public interface IUserBaseService
    {
        public Task<List<UserBase>> GetAllUsersAsync(CancellationToken cancellationToken);
    }
}
