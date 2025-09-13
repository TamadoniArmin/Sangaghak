using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace SangaghakRazorEndPoint.Areas.Public.Pages
{
    public class SeeCategoryDetailsModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public CategoryDTO Category { get; set; }
        [BindProperty]
        public List<SubCategoryDTO> SubCategories { get; set; }
        [BindProperty]
        public int SubCategoryCount { get; set; }
        public async Task OnGet(int CategoryId,CancellationToken cancellationToken)
        {
            Category= await categoryAppService.GetCategoryByIdAysnc(CategoryId, cancellationToken);
            SubCategories = await categoryAppService.GetSubCategoriesByParentId(CategoryId, cancellationToken);
            SubCategoryCount = SubCategories.Count();
        }
    }
}
