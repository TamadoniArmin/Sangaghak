using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IExpertRepository
    {
        #region Read
        public Task<int> GetExpertRateAsync(int ExpertId, CancellationToken cancellationToken);
        public Task<List<GetSubCategoryNameForExpertsDTO>?> GetExpertSkillsId(int ExpertId, CancellationToken cancellationToken);

        #endregion
        #region Update
        public Task<bool> SetExpertPointAsync(int CustomerId, int Point, int ExpertId, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteExpertAsync(int ExpertId, CancellationToken cancellationToken);
        #endregion
    }
}
