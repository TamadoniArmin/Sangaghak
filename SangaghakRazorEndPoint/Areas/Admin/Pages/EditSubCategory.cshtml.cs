using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Entities.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Categories;

namespace SangaghakRazorEndPoint.Areas.Admin.Pages
{
    public class EditSubCategoryModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public SubCategoryDTO WantedSubCategory { get; set; }
        [BindProperty]
        public SubCategoryDTO UpdateSubCategory { get; set; }
        public async Task OnGet(int SubCategoryId, CancellationToken cancellationToken)
        {
            WantedSubCategory = await categoryAppService.GetSubCategoryByIdAysnc(SubCategoryId, cancellationToken);
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var result = await categoryAppService.UpdateSubCategory(UpdateSubCategory, UpdateSubCategory.Id, cancellationToken);
            if (!result)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("SeeAllSubCategories");
            }
        }
    }
}
