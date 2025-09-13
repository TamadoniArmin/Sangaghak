using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.ServicePackages
{
    public class ServicePackageAppService : IServicePackageAppService
    {
        #region Dependency Injection
        private readonly IServicePackageService _service;
        private readonly ICategoryService _categoryService;
        private readonly IGeneralService _generalService;
        public ServicePackageAppService(IServicePackageService servicePackageService, ICategoryService categoryService, IGeneralService generalService)
        {
            _service = servicePackageService;
            _categoryService = categoryService;
            _generalService = generalService;
        }
        public async Task<bool> CreateServicePackage(ServicePackageForCreateDTO forCreateDTO, CancellationToken cancellationToken)
        {
            if(forCreateDTO.ImageFile is not null)
            {
                forCreateDTO.ImagePath = await _generalService.UploadImage(forCreateDTO.ImageFile,"Packages", cancellationToken);
            }
            return await _service.CreateServicePackage(forCreateDTO, cancellationToken);
        }
        #endregion
        #region Create
        #endregion
        #region Read
        public async Task<List<ServicePackageDTO>> FindPackageByTitle(string PackageTiltle, CancellationToken cancellationToken)
        {
            return await _service.FindPackageByTitle(PackageTiltle, cancellationToken);
        }
        public async Task<List<ServicePackageDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var Packages = await _service.GetAllAsync(cancellationToken);
            if (Packages is null) return null;
            else
            {
                foreach (var package in Packages)
                {
                    package.SubCategoryTitle = await _categoryService.GetSubCategoryNameByIdAysnc(package.SubCategoryId, cancellationToken);
                }
                return Packages;
            }
        }
        public async Task<List<ServicePackageDTO>> GetAllPackageBySubCategoryId(int SubCategoryId, CancellationToken cancellationToken)
        {
            return await _service.GetAllPackageBySubCategoryId(SubCategoryId, cancellationToken);
        }
        public async Task<int> GetAllPackageCount(CancellationToken cancellationToken)
        {
            return await _service.GetAllPackageCount(cancellationToken);
        }

        public async Task<ServicePackageDTO> GetPackageById(int PackageId, CancellationToken cancellationToken)
        {
            return await _service.GetPackageById(PackageId, cancellationToken);
        }

        public async Task<ServicePackageDTO> GetPackageByTitle(string PackageTiltle, CancellationToken cancellationToken)
        {
            return await _service.GetPackageByTitle(PackageTiltle, cancellationToken);
        }

        public async Task<string> GetPackageTiltleById(int PackageId, CancellationToken cancellationToken)
        {
            return await _service.GetPackageTiltleById(PackageId, cancellationToken);
        }







        #endregion
        #region Update
        public async Task<bool> UpdateServicePackage(ServicePackageForCreateDTO servicePackageDTO, int PackageId, CancellationToken cancellationToken)
        {
            if (servicePackageDTO.ImageFile is not null)
            {
                servicePackageDTO.ImagePath = await _generalService.UploadImage(servicePackageDTO.ImageFile, "Packages", cancellationToken);
            }
            return await _service.UpdateServicePackage(servicePackageDTO, PackageId, cancellationToken);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteServicePackage(int PackageId, CancellationToken cancellationToken)
        {
            return await _service.DeleteServicePackage(PackageId, cancellationToken);
        }
        #endregion
    }
}
