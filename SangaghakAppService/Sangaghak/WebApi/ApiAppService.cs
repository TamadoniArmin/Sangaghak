using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.WebApi
{
    public class ApiAppService : IApiAppService
    {
        #region Dependency Injection
        private readonly IApiService _apiService;
        public ApiAppService(IApiService apiService)
        {
            _apiService = apiService;
        }
        #endregion
        #region Read
        public async Task<List<CategoryWithSubCategoriesAndPackagesDTO>> GetAllCategoriesWithSubCategoriesAndPackagesAsync(CancellationToken cancellationToken)
        {
            return await _apiService.GetAllCategoriesWithSubCategoriesAndPackagesAsync(cancellationToken);
        }
        #endregion
    }
}
