using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Users;
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
        public async Task<List<UserBase>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllUsersAsync(cancellationToken);
        }
    }
}
