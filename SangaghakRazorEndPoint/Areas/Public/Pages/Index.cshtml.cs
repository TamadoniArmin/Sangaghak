using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
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

        public async Task<IActionResult> OnGetRedirect()
        {
            var userRoles = User.FindFirst(ClaimTypes.Role)?.Value;


            if (userRoles != null)
            {
                switch (userRoles)
                {
                    case "Admin":
                        return LocalRedirect("/Admin/Index");
                    case "Customer":
                        return LocalRedirect("/Customer/Index");
                    //case "Expert":
                    //    return RedirectToAction("Management", new { area = "Expert" });
                    default:
                        return LocalRedirect("/AccessDenied");
                }
            }

            // «ê— ‰ﬁ‘ ò«—»— ‰«„⁄ »— »«‘œ
            return RedirectToPage("/AccessDenied");
        }
    }
}
