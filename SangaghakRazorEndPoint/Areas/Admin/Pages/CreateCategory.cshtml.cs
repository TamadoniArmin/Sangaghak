using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin
{
    public class CreateCategoryModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public CategoryForCreateDto Category { get; set; }
        public void OnGet()
        {
            //ورودی آن گت این صفحه برسی شود با توجه به ریدایرکت پایین
        }
        public async Task<IActionResult> OnPostCreateCategory(CancellationToken cancellationToken)
        {
            var Result=await categoryAppService.CreateCategory(Category,cancellationToken);
            if (!Result)
            {
                TempData["Fail to Create Cagegory"] = "درخواست یجاد این کتگوری با شکست مواجه شد";
                return Page();
            }
            return RedirectToPage("SeeAllCategories");
        }
    }
}
