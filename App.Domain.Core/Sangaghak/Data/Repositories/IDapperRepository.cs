using App.Domain.Core.Sangaghak.DTOs.BaseEntities;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IDapperRepository
    {
        public Task<List<CityDTO>> GetAllCities(CancellationToken cancellationToken);
        public Task<List<CategoryDTO>> GetAllCategories(CancellationToken cancellationToken);
        public Task<List<SubCategoryDTO>> GetAllSubCategories(CancellationToken cancellationToken);
        public Task<List<ServicePackageDTO>> GetAllServicePackagesAsync(CancellationToken cancellationToken);
    }
}
