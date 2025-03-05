using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace SangaghakRazorEndPoint.Areas.Admin.Pages
{
    public class EditCategoryModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public CategoryDTO WantedCategory { get; set; }
        [BindProperty]
        public CategoryDTO UpdateCategory { get; set; }
        public int WantedCategoryId { get; set; }
        public async Task OnGet(int CategoryId, CancellationToken cancellationToken)
        {
            WantedCategory = await categoryAppService.GetCategoryByIdAysnc(CategoryId, cancellationToken);
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var result = await categoryAppService.UpdateCategory(UpdateCategory, UpdateCategory.Id, cancellationToken);
            if(!result)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("SeeAllCategories");
            }
        }
    }
}
