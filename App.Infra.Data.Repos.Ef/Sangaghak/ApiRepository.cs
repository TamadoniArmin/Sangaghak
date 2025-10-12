using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using Connection.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class ApiRepository : IApiRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<CategoryRepository> _logger;

        public ApiRepository(AppDbContext appDbContext, ILogger<CategoryRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<List<CategoryWithSubCategoriesAndPackagesDTO>> GetAllCategoriesWithSubCategoriesAndPackagesAsync(CancellationToken cancellationToken)
        {

                _logger.LogInformation("تلاش برای دریافت تمام دسته‌بندی‌ها با زیرمجموعه‌ها و بسته‌ها");

                var categories = await _appDbContext.Categories
                    .Where(c => c.IsDeleted == false && c.ParentId == null)
                    .Include(c => c.Subcategories)
                        .ThenInclude(sc => sc.Packages)
                    .Select(c => new CategoryWithSubCategoriesAndPackagesDTO
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Description = c.Description,
                        ImagePath = c.ImagePath ?? string.Empty,
                        SubCategories = c.Subcategories!
                            .Where(sc => sc.IsDeleted == false)
                            .Select(sc => new AllSubCategoryDTO
                            {
                                Id = sc.Id,
                                Title = sc.Title,
                                Description = sc.Description,
                                ImagePath = sc.ImagePath ?? string.Empty,
                                ParentId = sc.ParentId ?? 0,
                                Packages = sc.Packages
                                    .Where(p => p.IsDeleted == false)
                                    .Select(p => new AllServicePackageDTO
                                    {
                                        Id = p.Id,
                                        Title = p.Tiltle, // فرض بر اصلاح Tiltle به Title
                                        Description = p.Description,
                                        MinPrice = p.MinPrice,
                                        ImagePath = p.ImagePath ?? string.Empty,
                                        SubCategoryId = p.SubCategoryId
                                    }).ToList()
                            }).ToList()
                    }).ToListAsync(cancellationToken);

                return categories;
        }
    }
}
