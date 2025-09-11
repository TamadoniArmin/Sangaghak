using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Users
{
    [Authorize]
    public class SeeUserProfileModel(IUserBaseAppService userBaseAppService,IExpertAppService expertAppService) : PageModel
    {
        [BindProperty]
        public GetUserBaseForViewPage UserInfo { get; set; }
        [BindProperty]
        public List<GetSubCategoryNameForExpertsDTO>? ExpertSkills { get; set; }
        public async Task OnGet(int UserId,CancellationToken  cancellationToken)
        {
            UserInfo = await userBaseAppService.GetByIdAsync(UserId, cancellationToken);
            if(UserInfo.Role==App.Domain.Core.Sangaghak.Enum.RoleEnum.Expert)
            {
                ExpertSkills= await expertAppService.GetExpertSkillsId(UserId,cancellationToken);
            }
        }
    }
}
