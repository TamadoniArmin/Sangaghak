using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace SangaghakRazorEndPoint.Areas.Expert.Pages
{
    [Authorize(Roles = "Expert")]
    public class UpdateExpertSkillsModel(ICategoryAppService categoryAppService,
        IExpertAppService expertAppService) : PageModel
    {
        [BindProperty]
        public List<SubCategoryDTO> AllSubcategories { get; set; }
        [BindProperty]
        public List<int>? ExpertCurrentSkills { get; set; }
        public async Task<IActionResult> OnGet(int ExpertId,CancellationToken cancellationToken)
        {
            AllSubcategories = await categoryAppService.GetAllSubCategories(cancellationToken);
            if (AllSubcategories.IsNullOrEmpty())
            {
                return NotFound();
            }
            else
            {
                ExpertCurrentSkills = await categoryAppService.GetCategoryIdByExpertId(ExpertId, cancellationToken);
            }
            return Page();
        }
    }
}
