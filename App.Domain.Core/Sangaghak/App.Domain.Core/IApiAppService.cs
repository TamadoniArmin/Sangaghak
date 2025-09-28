using App.Domain.Core.Sangaghak.DTOs.Categories;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IApiAppService
    {
        #region Create
        #endregion
        #region Read
        public Task<List<CategoryWithSubCategoriesAndPackagesDTO>> GetAllCategoriesWithSubCategoriesAndPackagesAsync(CancellationToken cancellationToken);
        #endregion
        #region Update
        #endregion
        #region Delete
        #endregion
    }
}
