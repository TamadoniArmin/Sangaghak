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
        #region Create
        public async Task<bool> RegiterExpertAsync(string Email, string phoneNumber, string Password)
        {
            var NewExpert = await _appDbContext.Experts.AsNoTracking().FirstOrDefaultAsync(x => x.Email == Email);
            if (NewExpert != null)
            {
                Expert expert = new Expert();
                expert.Email = Email;
                expert.Phone = phoneNumber;
                expert.Password = Password;
                expert.RegisteredAt = DateTime.Now;
                await _appDbContext.Experts.AddAsync(expert);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
        #region Read

        public async Task<List<Expert>> GetAllExpertsAsync()
        {
            return await _appDbContext.Experts.AsNoTracking().Where(x=>x.IsDeleted == false).ToListAsync();
        }

        public async Task<int> GetExpertBalanceAsync(int ExpertId)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId && x.IsDeleted == false);
            if (Expert != null)
            {
                return Expert.Balance;
            }
            return -1;
        }

        public async Task<Expert> GetExpertByIdAsync(int id)
        {
            return await _appDbContext.Experts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Expert> GetExpertByNameAsync(string name)
        {
            return await _appDbContext.Experts.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == name && x.IsDeleted == false);
        }

        public async Task<int> GetExpertRateAsync(int ExpertId)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId && x.IsDeleted == false);
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

        public async Task<bool> LoginExpertAsync(string Email, string Password)
        {
            var Expert = await _appDbContext.Experts.AsNoTracking().FirstOrDefaultAsync(x => x.Email == Email && x.Password == Password && x.IsDeleted == false);
            if (Expert != null)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Update
        public async Task<bool> IncreaseExpertBalanceAsync(int Money, int ExpertId)
        {
            var Customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == ExpertId);
            if (Customer != null)
            {
                Customer.Balance += Money;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DecreaseExpertBalanceAsync(int Money, int ExpertId)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId);
            if (Expert != null)
            {
                if (Expert.Balance < Money)
                {
                    return false;
                }
                else if (Expert.Balance > Money)
                {
                    Expert.Balance -= Money;
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> SetExpertPointAsync(int CustomerId, int Point, int ExpertId)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId);
            if (Expert != null)
            {
                Expert.PointerIds.Add(CustomerId);
                Expert.Points.Add(Point);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateExpertInformationAsync(Expert expert, int ExpertId)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId);
            if (Expert != null)
            {
                Expert.UserName = expert.UserName;
                Expert.FirstName = expert.FirstName;
                Expert.LastName = expert.LastName;
                Expert.CityId = expert.CityId;
                Expert.City = expert.City;
                Expert.Image.Id = expert.Image.Id;
                Expert.Image.Path = expert.Image.Path;
                await _appDbContext.AddAsync(expert);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteExpertAsync(int ExpertId)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId && x.IsDeleted == false);
            if (Expert != null)
            {
                Expert.IsDeleted = true;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
    }
}
