using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Entities.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin
{
    public class CreateSubCategoryModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public SubCategoryFroCreateDto SubCategory { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var Result = await categoryAppService.CreateSubCategory(SubCategory, cancellationToken);
            if (!Result)
            {
                TempData["Fail to Create Cagegory"] = "درخواست یجاد این زیرکتگوری با شکست مواجه شد";
                return Page();
            }
            return RedirectToPage("SeeAllCategories");
        }
    }
}
