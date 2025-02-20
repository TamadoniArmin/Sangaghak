using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Users;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class ExpertRepository : IExpertRepository
    {
        #region Dependency Injection
        private readonly AppDbContext _appDbContext;
        public ExpertRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        #endregion
        #region Read

        public async Task<List<Expert>> GetAllExpertsAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Experts.AsNoTracking().Where(x=>x.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task<int> GetExpertBalanceAsync(int ExpertId, CancellationToken cancellationToken)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId && x.IsDeleted == false,cancellationToken);
            if (Expert != null)
            {
                return Expert.Balance;
            }
            return -1;
        }

        public async Task<Expert> GetExpertByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Experts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false,cancellationToken);
        }

        public async Task<Expert> GetExpertByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _appDbContext.Experts.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == name && x.IsDeleted == false,cancellationToken);
        }

        public async Task<int> GetExpertRateAsync(int ExpertId, CancellationToken cancellationToken)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId && x.IsDeleted == false,cancellationToken);
            if (Expert != null)
            {
                int PointerCount = Expert.PointerIds.Count();
                int sum = 0;
                foreach (var Point in Expert.Points)
                {
                    sum += Point;
                }
                return sum / PointerCount;
            }
            return -1;
        }
        #endregion
        #region Update
        public async Task<bool> IncreaseExpertBalanceAsync(int Money, int ExpertId, CancellationToken cancellationToken)
        {
            var Customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == ExpertId,cancellationToken);
            if (Customer != null)
            {
                Customer.Balance += Money;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        public async Task<bool> DecreaseExpertBalanceAsync(int Money, int ExpertId, CancellationToken cancellationToken)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId,cancellationToken);
            if (Expert != null)
            {
                if (Expert.Balance < Money)
                {
                    return false;
                }
                else if (Expert.Balance > Money)
                {
                    Expert.Balance -= Money;
                    await _appDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> SetExpertPointAsync(int CustomerId, int Point, int ExpertId, CancellationToken cancellationToken)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId,cancellationToken);
            if (Expert != null)
            {
                Expert.PointerIds.Add(CustomerId);
                Expert.Points.Add(Point);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateExpertInformationAsync(Expert expert, int ExpertId, CancellationToken cancellationToken)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId,cancellationToken);
            if (Expert != null)
            {
                Expert.UserName = expert.UserName;
                Expert.FirstName = expert.FirstName;
                Expert.LastName = expert.LastName;
                Expert.CityId = expert.CityId;
                Expert.City = expert.City;
                Expert.Image.Id = expert.Image.Id;
                Expert.Image.Path = expert.Image.Path;
                await _appDbContext.AddAsync(expert,cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteExpertAsync(int ExpertId, CancellationToken cancellationToken)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId && x.IsDeleted == false,cancellationToken);
            if (Expert != null)
            {
                Expert.IsDeleted = true;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
    }
}
