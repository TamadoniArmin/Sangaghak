using App.Domain.Core.Sangaghak.DTOs.Categories;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IApiAppService
    {
        public Task<List<CategoryWithSubCategoriesAndPackagesDTO>> GetAllCategoriesWithSubCategoriesAndPackagesAsync(CancellationToken cancellationToken);
    }
}
