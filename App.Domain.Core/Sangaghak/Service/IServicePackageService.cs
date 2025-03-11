using App.Domain.Core.Sangaghak.DTOs.ServicePackages;

namespace App.Domain.Core.Sangaghak.Service
{
    public interface IServicePackageService
    {
        #region Create
        public Task<bool> CreateServicePackage(ServicePackageForCreateDTO forCreateDTO, CancellationToken cancellationToken);
        #endregion
        #region Read
        public Task<List<ServicePackageDTO>> GetAllAsync(CancellationToken cancellationToken);
        public Task<int> GetAllPackageCount(CancellationToken cancellationToken);
        public Task<List<ServicePackageDTO>> GetAllPackageBySubCategoryId(int SubCategoryId, CancellationToken cancellationToken);
        public Task<ServicePackageDTO> GetPackageById(int PackageId, CancellationToken cancellationToken);
        public Task<ServicePackageDTO> GetPackageByTitle(string PackageTiltle, CancellationToken cancellationToken);
        public Task<List<ServicePackageDTO>> FindPackageByTitle(string PackageTiltle, CancellationToken cancellationToken);
        public Task<string> GetPackageTiltleById(int PackageId, CancellationToken cancellationToken);
        #endregion
        #region Update
        public Task<bool> UpdateServicePackage(ServicePackageForCreateDTO servicePackageDTO, int PackageId, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteServicePackage(int PackageId, CancellationToken cancellationToken);
        #endregion
    }
}
