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
        IServicePackageAppService servicePackageAppService,
        IApiAppService apiAppService) : ControllerBase
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


        [HttpGet("Get-All-Data-Category")]
        public async Task<IActionResult> GetAllCategoriesWithSubCategoriesAndPackagesAsync(CancellationToken cancellationToken)
        {
            var model=await apiAppService.GetAllCategoriesWithSubCategoriesAndPackagesAsync(cancellationToken);
            var result = new ApiResult<List<CategoryWithSubCategoriesAndPackagesDTO>, string, string>
            {
                IsSuccess = true,
                Massage="درخواست با موفقیت اجرا شد",
                Result1 = model,
                Result2="این دیتا نیازی به پر کردن این قسمت ندارد",
                Result3="این دیتا نیازی به پر کردن این قسمت ندارد"
            };
            return Ok(result);
        }
    }
}
