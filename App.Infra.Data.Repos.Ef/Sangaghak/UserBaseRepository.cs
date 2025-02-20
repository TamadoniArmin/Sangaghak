using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Users;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class UserBaseRepository : IUserBaseRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserBaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<UserBase>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Users.ToListAsync(cancellationToken);
        }
    }
}
