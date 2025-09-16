using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IServicePackageAppService
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
        public Task<ServicePackageBasicInfoDTO?> GetPackageBasicInfo(int PackageId, CancellationToken cancellationToken);

        #endregion
        #region Update
        public Task<bool> UpdateServicePackage(ServicePackageForCreateDTO servicePackageDTO, int PackageId, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteServicePackage(int PackageId, CancellationToken cancellationToken);
        #endregion
    }
}
