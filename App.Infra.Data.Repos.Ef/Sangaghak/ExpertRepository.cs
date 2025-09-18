using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Categories;
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
        public async Task<bool> CheckExpertHasAnySkillAsync(int ExpertId,CancellationToken cancellationToken)
        {
            var WantedExpert = await _appDbContext.Experts
                 .Where(x => x.Id == ExpertId && x.IsDeleted == false)
                 .Include(x => x.Skills)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(cancellationToken);
            if (WantedExpert is null)
            {
                return false;
            }
            else
            {
                if(WantedExpert.Skills.Any())
                {
                    return true;
                }
            }
            return false;
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
        public async Task<bool> SetExpertPointAsync(int CustomerId, int Point, int ExpertId, CancellationToken cancellationToken)
        {
            var Expert = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == ExpertId && x.IsDeleted == false, cancellationToken);
            if (Expert != null)
            {
                Expert.PointerIds.Add(CustomerId);
                Expert.Points.Add(Point);
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
