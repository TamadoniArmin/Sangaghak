using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Pages;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    [Authorize(Roles = ("Customer"))]
    public class SeeExpertProfileModel(IExpertProfileAppService expertProfileAppService,
        IUserBaseAppService userBaseAppService) : PageModel
    {
        [BindProperty]
        public GetUserBaseForViewPage WantedUser { get; set; }//done
        [BindProperty]
        public int ExpertRate { get; set; }//done
        [BindProperty]
        public List<GetSubCategoryNameForExpertsDTO> ExpertSkillsNames { get; set; }//done
        [BindProperty]
        public List<CommentDTO>? ExpertComments { get; set; }//done

        public async Task<IActionResult> OnGet(int ExpertId, CancellationToken cancellationToken)
        {
            var wanteduser = await userBaseAppService.GetExpertBasicInfoByExpertIdAsync(ExpertId, cancellationToken);
            WantedUser = await expertProfileAppService.UserSummary(wanteduser!.Id, cancellationToken);
            if (WantedUser is null)
            {
                return NotFound();
            }
            else
            {
                ExpertRate = await expertProfileAppService.GetExpertRateAysnc(ExpertId, cancellationToken);
                var Skills = await expertProfileAppService.GetExpertSkillsNameByExpertId(ExpertId, cancellationToken);
                if (Skills is not null && Skills.Any())
                {
                    ExpertSkillsNames = Skills;
                }
                ExpertComments = await expertProfileAppService.GetExpertCommentsAsync(ExpertId, cancellationToken);
            }
            
            return Page();
        }
    }
}
