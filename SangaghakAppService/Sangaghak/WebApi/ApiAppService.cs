using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.WebApi
{
    public class ApiAppService : IApiAppService
    {
        private readonly IApiService _apiService;
        public ApiAppService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<List<CategoryWithSubCategoriesAndPackagesDTO>> GetAllCategoriesWithSubCategoriesAndPackagesAsync(CancellationToken cancellationToken)
        {
            return await _apiService.GetAllCategoriesWithSubCategoriesAndPackagesAsync(cancellationToken);
        }
    }
}
