using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Categories;
using SangaghakAppService.Sangaghak.ServicePackages;
using System.Text;
using System.Web;

namespace SangaghakRazorEndPoint.Areas.Public.Pages
{
    public class SeeSubCategoryDetailsModel(ICategoryAppService categoryAppService,
        IServicePackageAppService servicePackageAppService) : PageModel
    {


        [BindProperty]
        public SubCategoryDTO SubCategory { get; set; }
        [BindProperty]
        public CategotyOrSubCategoryBasicInfo? ParentCategoryInfo { get; set; }
        [BindProperty]
        public List<ServicePackageDTO>? ServicePackages { get; set; }
        [BindProperty]
        public string ParentCategoryHtml { get; set; } // برای inner-banner
        [BindProperty]
        public string SubCategoryImageHtml { get; set; } // برای تصویر
        [BindProperty]
        public string ServicePackagesHtml { get; set; } // برای پکیج‌ها


        public async Task<IActionResult> OnGet(int SubCategoryId, CancellationToken cancellationToken)
        {
            try
            {
                // دریافت اطلاعات SubCategory
                SubCategory = await categoryAppService.GetSubCategoryByIdAysnc(SubCategoryId, cancellationToken);
                if (SubCategory == null)
                {
                    Console.WriteLine("SubCategory is null");
                    return NotFound();
                }

                // دریافت اطلاعات ParentCategory
                ParentCategoryInfo = await categoryAppService.GetCategoryBasicInfo(SubCategory.Id, cancellationToken);

                // دریافت ServicePackages
                ServicePackages = await servicePackageAppService.GetAllPackageBySubCategoryId(SubCategoryId, cancellationToken);
                Console.WriteLine($"ServicePackages Count: {(ServicePackages != null ? ServicePackages.Count : "null")}");

                // تولید HTML برای بخش‌های مختلف
                ParentCategoryHtml = GenerateParentCategoryHtml(ParentCategoryInfo);

                return Page();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500);
            }
        }

        private string GenerateParentCategoryHtml(CategotyOrSubCategoryBasicInfo? parentCategory)
        {
            if (parentCategory != null)
            {
                return $@"<a asp-page=""SeeCategoryDetails"" asp-route-CategoryId=""{parentCategory.Id}"">{HttpUtility.HtmlEncode(parentCategory.Title)}</a>";
            }
            return string.Empty;
        }
    }
}