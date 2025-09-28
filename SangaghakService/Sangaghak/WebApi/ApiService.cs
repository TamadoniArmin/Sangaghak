using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.WebApi
{
    public class ApiService : IApiService
    {
        #region Dependency Injection
        private readonly IApiRepository _apiRepository;
        public ApiService(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }
        #endregion
        #region Read
        public async Task<List<CategoryWithSubCategoriesAndPackagesDTO>> GetAllCategoriesWithSubCategoriesAndPackagesAsync(CancellationToken cancellationToken)
        {
            return await _apiRepository.GetAllCategoriesWithSubCategoriesAndPackagesAsync(cancellationToken);
        }
        #endregion
    }
}
