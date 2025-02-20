using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IUserBaseRepository
    {
        public Task<List<UserBase>> GetAllUsersAsync(CancellationToken cancellationToken);
    }
}
