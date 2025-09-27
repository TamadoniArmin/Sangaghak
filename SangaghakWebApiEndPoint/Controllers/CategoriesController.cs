using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using Microsoft.AspNetCore.Mvc;
using SangaghakWebApiEndPoint.WebFramework.ApiHelper;

namespace SangaghakWebApiEndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryAppService categoryAppService,
        IServicePackageAppService servicePackageAppService) : ControllerBase
    {
        [HttpGet("Get-All-Categories")]
        public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
        {
            var allCategories= await categoryAppService.GetAllCategories(cancellationToken);
            var allSubcategories= await categoryAppService.GetAllSubCategories(cancellationToken);
            var allPackagies= await servicePackageAppService.GetAllAsync(cancellationToken);
            var result = new ApiResult<List<CategoryDTO>, List<SubCategoryDTO>, List<ServicePackageDTO>>
            {
                IsSuccess = true,
                Result1 = allCategories,
                Result2=allSubcategories,
                Result3=allPackagies,
            };
            return Ok(result);
        }
    }
}
