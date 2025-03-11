using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace SangaghakRazorEndPoint.Areas.Public.Pages
{
    public class IndexModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public List<CategoryDTO> Categories { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            Categories = await categoryAppService.GetAllParentsCategory(cancellationToken);
        }
    }
}
