using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Pages
{
    public class SeeAllSubCategoriesModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public List<SubCategoryDTO> Childs { get; set; }
        [BindProperty]
        public int ChildCategoryId { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            Childs = await categoryAppService.GetAllSubCategories(cancellationToken);
        }
    }
}
