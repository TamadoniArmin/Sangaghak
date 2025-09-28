using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.ServicePackages
{
    public class ServicePackageService : IServicePackageService
    {
        #region Dependency Injection
        private readonly IServicePackageRepository _servicePackageRepository;
        private readonly IDapperRepository _dapperRepository;
        public ServicePackageService(IServicePackageRepository servicePackageRepository,
           IDapperRepository dapperRepository)
        {
            _servicePackageRepository = servicePackageRepository;
            _dapperRepository = dapperRepository;
        }
        #endregion
        #region Create
        public async Task<bool> CreateServicePackage(ServicePackageForCreateDTO forCreateDTO, CancellationToken cancellationToken)
        {
            return await _servicePackageRepository.CreateServicePackage(forCreateDTO, cancellationToken);
        }
        #endregion
        #region Read
        public async Task<List<ServicePackageDTO>> FindPackageByTitle(string PackageTiltle, CancellationToken cancellationToken)
        {
            return await _servicePackageRepository.FindPackageByTitle(PackageTiltle, cancellationToken);
        }

        public async Task<List<ServicePackageDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dapperRepository.GetAllServicePackagesAsync(cancellationToken);
        }

        public async Task<List<ServicePackageDTO>> GetAllPackageBySubCategoryId(int SubCategoryId, CancellationToken cancellationToken)
        {
            return await _servicePackageRepository.GetAllPackageBySubCategoryId(SubCategoryId, cancellationToken);
        }

        public async Task<int> GetAllPackageCount(CancellationToken cancellationToken)
        {
            return await _servicePackageRepository.GetAllPackageCount(cancellationToken);
        }

        public async Task<List<int>> GetCategoryPackagesIdbyCategoriesIdAsync(List<int> CategoriesId, CancellationToken cancellationToken)
        {
            return await _servicePackageRepository.GetCategoryPackagesIdbyCategoriesIdAsync(CategoriesId, cancellationToken);
        }

        public async Task<ServicePackageBasicInfoDTO?> GetPackageBasicInfo(int PackageId, CancellationToken cancellationToken)
        {
            return await _servicePackageRepository.GetPackageBasicInfo(PackageId, cancellationToken);
        }

        public async Task<ServicePackageDTO> GetPackageById(int PackageId, CancellationToken cancellationToken)
        {
            return await _servicePackageRepository.GetPackageById(PackageId, cancellationToken);
        }

        public async Task<ServicePackageDTO> GetPackageByTitle(string PackageTiltle, CancellationToken cancellationToken)
        {
            return await _servicePackageRepository.GetPackageByTitle(PackageTiltle, cancellationToken);
        }

        public async Task<string> GetPackageTiltleById(int PackageId, CancellationToken cancellationToken)
        {
            return await _servicePackageRepository.GetPackageTiltleById(PackageId, cancellationToken);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateServicePackage(ServicePackageForCreateDTO servicePackageDTO, int PackageId, CancellationToken cancellationToken)
        {
            return await _servicePackageRepository.UpdateServicePackage(servicePackageDTO, PackageId, cancellationToken);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteServicePackage(int PackageId, CancellationToken cancellationToken)
        {
            return await _servicePackageRepository.DeleteServicePackage(PackageId, cancellationToken);
        }
        #endregion
    }
}
