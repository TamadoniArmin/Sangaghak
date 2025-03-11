using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Public.Pages
{
    public class SeeSubCategoryDetailsModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public SubCategoryDTO SubCategory { get; set; }
        public async Task OnGet(int SubCategoryId, CancellationToken cancellationToken)
        {
            SubCategory = await categoryAppService.GetSubCategoryByIdAysnc(SubCategoryId, cancellationToken);
        }
    }
}
