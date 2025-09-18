using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Entities.ServicePackages;
using Connection.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class ServicePackageRepository : IServicePackageRepository
    {
        #region DI
        private readonly AppDbContext _context;
        public ServicePackageRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        #endregion
        #region Create
        public async Task<bool> CreateServicePackage(ServicePackageForCreateDTO forCreateDTO, CancellationToken cancellationToken)
        {
            try
            {
                var Package = new ServicePackage();

                Package.Tiltle = forCreateDTO.Title;
                Package.Description = forCreateDTO.Description;
                Package.MinPrice = forCreateDTO.MinPrice;
                Package.SubCategoryId = forCreateDTO.SubCategoryId;
                Package.ImagePath = forCreateDTO.ImagePath;
                await _context.Packages.AddAsync(Package, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception("Exception");
            }
        }
        #endregion
        #region Read
        public async Task<List<ServicePackageDTO>> FindPackageByTitle(string PackageTiltle, CancellationToken cancellationToken)
        {
            var Packages = await _context
            .Packages
            .Where(x => x.Tiltle.Contains(PackageTiltle) && x.IsDeleted == false)
            .Select(x => new ServicePackageDTO
            {
                Id = x.Id,
                Title = x.Tiltle,
                Description = x.Description,
                MinPrice = x.MinPrice,
                SubCategoryId = x.SubCategoryId,
                ImagePath = x.ImagePath,
            }).ToListAsync(cancellationToken);
            return Packages;
        }

        public async Task<List<ServicePackageDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var Result = await _context.Packages.AnyAsync(cancellationToken);
            if (Result)
            {
                return await _context.Packages
                    .Where(x => x.IsDeleted == false)
                    .Select(x => new ServicePackageDTO()
                    {
                        Id = x.Id,
                        Title = x.Tiltle,
                        Description = x.Description,
                        MinPrice = x.MinPrice,
                        SubCategoryId = x.SubCategoryId,
                        ImagePath = x.ImagePath
                    })
                    .ToListAsync(cancellationToken);
            }
            else return null;
        }

        public async Task<List<ServicePackageDTO>> GetAllPackageBySubCategoryId(int SubCategoryId, CancellationToken cancellationToken)
        {
            return await _context
                .Packages
                .Where(x => x.SubCategoryId == SubCategoryId && x.IsDeleted == false)
                .Select(x => new ServicePackageDTO()
                {
                    Id = x.Id,
                    Title = x.Tiltle,
                    Description = x.Description,
                    MinPrice = x.MinPrice,
                    SubCategoryId = x.SubCategoryId,
                    ImagePath = x.ImagePath
                }
                ).ToListAsync(cancellationToken);
        }

        public async Task<int> GetAllPackageCount(CancellationToken cancellationToken)
        {
            return await _context.Packages.Where(c => c.IsDeleted == false).CountAsync(cancellationToken);
        }

        public async Task<ServicePackageDTO> GetPackageById(int PackageId, CancellationToken cancellationToken)
        {
            var Package = await _context.Packages.FirstOrDefaultAsync(x => x.Id == PackageId && x.IsDeleted == false);
            if (Package is null) return null;
            else
            {
                ServicePackageDTO servicePackageDTO = new ServicePackageDTO();
                servicePackageDTO.Id = Package.Id;
                servicePackageDTO.Description = Package.Description;
                servicePackageDTO.MinPrice = Package.MinPrice;
                servicePackageDTO.ImagePath = Package.ImagePath ?? string.Empty;
                servicePackageDTO.SubCategoryId = Package.SubCategoryId;
                return servicePackageDTO;
            }
        }

        public async Task<ServicePackageDTO> GetPackageByTitle(string PackageTiltle, CancellationToken cancellationToken)
        {
            var Package = await _context.Packages.FirstOrDefaultAsync(x => x.Tiltle == PackageTiltle && x.IsDeleted == false);
            if (Package is null) return null;
            else
            {
                ServicePackageDTO servicePackageDTO = new ServicePackageDTO();
                servicePackageDTO.Id = Package.Id;
                servicePackageDTO.Description = Package.Description;
                servicePackageDTO.MinPrice = Package.MinPrice;
                servicePackageDTO.ImagePath = Package.ImagePath ?? string.Empty;
                servicePackageDTO.SubCategoryId = Package.SubCategoryId;
                return servicePackageDTO;
            }
        }

        public async Task<string> GetPackageTiltleById(int PackageId, CancellationToken cancellationToken)
        {
            var Package = await _context.Packages.FirstOrDefaultAsync(x => x.Id == PackageId && x.IsDeleted == false);
            if (Package is null) return string.Empty;
            else return Package.Tiltle;
        }
        public async Task<ServicePackageBasicInfoDTO?> GetPackageBasicInfo(int PackageId, CancellationToken cancellationToken)
        {
            var WantedPackage= await _context.Packages
                .Where(x => x.Id == PackageId && x.IsDeleted == false)
                .Select(x => new ServicePackageBasicInfoDTO
                {
                    Id = x.Id,
                    Tiltle = x.Tiltle,
                    MinPrice = x.MinPrice
                }).FirstOrDefaultAsync(cancellationToken);
            if (WantedPackage is null)
            {
                return null;
            }
            else
            {
                return WantedPackage;
            }
        }
        public async Task<List<int>>GetCategoryPackagesIdbyCategoriesIdAsync(List<int>  CategoriesId, CancellationToken cancellationToken)
        {
            return await _context.Packages
                .Where(x=> CategoriesId.Contains(x.SubCategoryId))
                .AsNoTracking()
                .Select(x=>x.Id)
                .ToListAsync(cancellationToken);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateServicePackage(ServicePackageForCreateDTO servicePackageDTO, int PackageId, CancellationToken cancellationToken)
        {
            var Package = await _context.Packages.FirstOrDefaultAsync(x => x.Id == PackageId && x.IsDeleted == false, cancellationToken);
            if (Package == null) return false;
            Package.Tiltle = servicePackageDTO.Title;
            Package.Description = servicePackageDTO.Description;
            Package.MinPrice = servicePackageDTO.MinPrice;
            Package.SubCategoryId = servicePackageDTO.SubCategoryId;
            if (servicePackageDTO.ImagePath is not null)
                Package.ImagePath = servicePackageDTO.ImagePath;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteServicePackage(int PackageId, CancellationToken cancellationToken)
        {
            var Package = await _context.Packages.FirstOrDefaultAsync(x => x.Id == PackageId && x.IsDeleted == false);
            if (Package is null) return false;
            else
            {
                Package.IsDeleted = true;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
        #endregion
    }
}
