using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Categories;

namespace SangaghakRazorEndPoint.Areas.Admin
{
    public class SeeAllCategoriesModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public List<CategoryDTO> Parents { get; set; }
        [BindProperty]
        public int ParentId { get; set; }

        public async Task OnGet(int parentId, int childCategoryId,CancellationToken  cancellationToken)
        {
            Parents = await categoryAppService.GetAllParentsCategory(cancellationToken);
        }
        public async Task<IActionResult> OnGetDelete(int categoryId, CancellationToken cancellationToken)
        {
            var result = await categoryAppService.DeleteCategory(categoryId, cancellationToken);
            if (result)
            {
                return RedirectToPage("SeeAllCategories");
            }
            return RedirectToPage("SeeAllCategories");
        }
    }
}
