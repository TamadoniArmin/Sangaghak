using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Users
{
    [Authorize(Roles = ("Admin"))]
    public class SeeUserProfileModel(IUserBaseAppService userBaseAppService,
        IExpertProfileAppService expertProfileAppService) : PageModel
    {
        [BindProperty]
        public GetUserBaseForViewPage UserInfo { get; set; }
        [BindProperty]
        public int ExpertRate { get; set; }//done
        [BindProperty]
        public List<GetSubCategoryNameForExpertsDTO> ExpertSkillsNames { get; set; }//done
        [BindProperty]
        public List<CommentDTO>? ExpertComments { get; set; }//done
        public async Task<IActionResult> OnGet(int UserId,CancellationToken  cancellationToken)
        {
            UserInfo = await userBaseAppService.GetByIdAsync(UserId, cancellationToken);
            if (UserInfo is null)
            {
                return NotFound();
            }
            else
            {
                if(UserInfo.ExpertId !=null && UserInfo.ExpertId!=0 && UserInfo.Role==App.Domain.Core.Sangaghak.Enum.RoleEnum.Expert)
                {
                    ExpertRate = await expertProfileAppService.GetExpertRateAysnc(UserInfo.ExpertId.Value, cancellationToken);
                    var Skills = await expertProfileAppService.GetExpertSkillsNameByExpertId(UserInfo.ExpertId.Value, cancellationToken);
                    if (Skills is not null && Skills.Any())
                    {
                        ExpertSkillsNames = Skills;
                    }
                    ExpertComments = await expertProfileAppService.GetExpertCommentsAsync(UserInfo.ExpertId.Value, cancellationToken);
                }
                return Page();
            }
        }
    }
}
