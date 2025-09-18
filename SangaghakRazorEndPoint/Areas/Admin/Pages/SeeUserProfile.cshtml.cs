using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Users
{
    [Authorize]
    public class SeeUserProfileModel(IUserBaseAppService userBaseAppService,
        ICategoryAppService categoryAppService,
        IExpertProfileAppService expertProfileAppService) : PageModel
    {
        [BindProperty]
        public GetUserBaseForViewPage UserInfo { get; set; }
        [BindProperty]
        public List<GetSubCategoryNameForExpertsDTO>? ExpertSkills { get; set; }
        public async Task<IActionResult> OnGet(int UserId,CancellationToken  cancellationToken)
        {
            UserInfo = await userBaseAppService.GetByIdAsync(UserId, cancellationToken);
            if (UserInfo is null)
            {
                return NotFound();
            }
            else
            {
                if (UserInfo.Role == App.Domain.Core.Sangaghak.Enum.RoleEnum.Expert)
                {
                    if (UserInfo.ExpertId is null || UserInfo.ExpertId == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        ExpertSkills = await expertProfileAppService.GetExpertSkillsNameByExpertId(UserInfo.ExpertId.Value, cancellationToken);
                    }
                }
                return Page();
            }
        }
    }
}
