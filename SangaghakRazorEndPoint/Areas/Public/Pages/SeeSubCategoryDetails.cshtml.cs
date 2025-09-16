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
                SubCategoryImageHtml = GenerateSubCategoryImageHtml(SubCategory);
                //ServicePackagesHtml = GenerateServicePackagesHtml(ServicePackages);

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

        private string GenerateSubCategoryImageHtml(SubCategoryDTO subCategory)
        {
            if (subCategory.ImagePath != null)
            {
                return $@"<img src=""{HttpUtility.HtmlEncode(subCategory.ImagePath)}"" alt=""Images"">";
            }
            return @"<img src=""~/MainTemplate/images/find-jobs/find-jobs3.jpg"" alt=""Images"">";
        }

        //private string GenerateServicePackagesHtml(List<ServicePackageDTO>? servicePackages)
        //{
        //    var htmlBuilder = new StringBuilder();

        //    if (servicePackages?.Any() == true)
        //    {
        //        foreach (var package in servicePackages)
        //        {
        //            htmlBuilder.AppendLine(
        //                $@"<div class=""col-lg-12"">
        //                    <div class=""recent-job-card box-shadow"">
        //                        <div class=""content"">
        //                            <h3><a href=""job-details.html"">{HttpUtility.HtmlEncode(package.Title)}</a></h3>
        //                            <ul class=""job-list1"">
        //                                <li>{HttpUtility.HtmlEncode(package.SubCategoryTitle)}</li>
        //                            </ul>
        //                            <span>{HttpUtility.HtmlEncode(package.Description)}</span>
        //                        </div>
        //                        <div class=""job-sub-content"">
        //                            <ul class=""job-list2"">
        //                                <li class=""time"">
        //                                    <a asp-area=""Customer"" asp-page=""PostRequestWithPackageId"" asp-route-PackageId=""{package.Id}"">ثبت درخواست</a>
        //                                </li>
        //                            </ul>
        //                            <div class=""price"">{HttpUtility.HtmlEncode(package.MinPrice.ToString())} <b>:شروع قیمت</b></div>
        //                        </div>
        //                    </div>
        //                </div>");
        //        }
        //    }
        //    else
        //    {
        //        htmlBuilder.AppendLine("<h4>در حال حاضر پکیجی برای این حوزه در نظر گرفته نشده</h4>");
        //    }

        //    return htmlBuilder.ToString();
        //}
    }
}