using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.ServicePackages
{
    public class ServicePackageService(IServicePackageRepository servicePackageRepository) : IServicePackageService
    {
        public async Task<bool> CreateServicePackage(ServicePackageForCreateDTO forCreateDTO, CancellationToken cancellationToken)
        {
            return await servicePackageRepository.CreateServicePackage(forCreateDTO, cancellationToken);
        }

        public async Task<bool> DeleteServicePackage(int PackageId, CancellationToken cancellationToken)
        {
            return await servicePackageRepository.DeleteServicePackage(PackageId, cancellationToken);
        }

        public async Task<List<ServicePackageDTO>> FindPackageByTitle(string PackageTiltle, CancellationToken cancellationToken)
        {
            return await servicePackageRepository.FindPackageByTitle(PackageTiltle, cancellationToken);
        }

        public async Task<List<ServicePackageDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await servicePackageRepository.GetAllAsync(cancellationToken);
        }

        public async Task<List<ServicePackageDTO>> GetAllPackageBySubCategoryId(int SubCategoryId, CancellationToken cancellationToken)
        {
            return await servicePackageRepository.GetAllPackageBySubCategoryId(SubCategoryId, cancellationToken);
        }

        public async Task<int> GetAllPackageCount(CancellationToken cancellationToken)
        {
            return await servicePackageRepository.GetAllPackageCount(cancellationToken);
        }

        public async Task<ServicePackageBasicInfoDTO?> GetPackageBasicInfo(int PackageId, CancellationToken cancellationToken)
        {
            return await servicePackageRepository.GetPackageBasicInfo(PackageId, cancellationToken);
        }

        public async Task<ServicePackageDTO> GetPackageById(int PackageId, CancellationToken cancellationToken)
        {
            return await servicePackageRepository.GetPackageById(PackageId, cancellationToken);
        }

        public async Task<ServicePackageDTO> GetPackageByTitle(string PackageTiltle, CancellationToken cancellationToken)
        {
            return await servicePackageRepository.GetPackageByTitle(PackageTiltle, cancellationToken);
        }

        public async Task<string> GetPackageTiltleById(int PackageId, CancellationToken cancellationToken)
        {
            return await servicePackageRepository.GetPackageTiltleById(PackageId, cancellationToken);
        }

        public async Task<bool> UpdateServicePackage(ServicePackageForCreateDTO servicePackageDTO, int PackageId, CancellationToken cancellationToken)
        {
            return await servicePackageRepository.UpdateServicePackage(servicePackageDTO, PackageId, cancellationToken);
        }
    }
}
