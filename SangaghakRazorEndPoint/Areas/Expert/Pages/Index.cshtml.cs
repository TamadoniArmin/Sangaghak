using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Pages;

namespace SangaghakRazorEndPoint.Areas.Expert.Pages
{
    [Authorize]
    public class IndexModel(IExpertProfileAppService expertProfileAppService) : PageModel
    {
        [BindProperty]
        public GetUserBaseForViewPage WantedUser { get; set; }//done
        [BindProperty]
        public int ExpertRate { get; set; }//done
        [BindProperty]
        public List<GetSubCategoryNameForExpertsDTO> ExpertSkillsNames { get; set; }//done
        [BindProperty]
        public int MatchRequestsForThisExpertCount { get; set; }//done
        [BindProperty]
        public List<RequestDTO>? AllCurrentExpertRequests { get; set; }//done
        [BindProperty]
        public int UserBalance { get; set; }//done
        [BindProperty]
        public int AllExpertRequestCount { get; set; }//done
        [BindProperty]
        public int AllExpertOfferCount { get; set; }//done
        [BindProperty]
        public List<CommentDTO>? ExpertComments { get; set; }//done

        public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
        {
            int userid = int.Parse(User.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value);
            if (userid== 0)
            {
                return NotFound();
            }
            else
            {
                WantedUser = await expertProfileAppService.UserSummary(userid, cancellationToken);
                if (WantedUser is null)
                {
                    return NotFound();
                }
                else
                {
                    UserBalance = await expertProfileAppService.GetUserBalance(userid, cancellationToken);
                    int ExpertID = await expertProfileAppService.GetExpertId(userid, cancellationToken);
                    if (ExpertID == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        ExpertRate = await expertProfileAppService.GetExpertRateAysnc(ExpertID,cancellationToken);
                        var Skills = await expertProfileAppService.GetExpertSkillsNameByExpertId(ExpertID, cancellationToken);
                        if (Skills is not null && Skills.Any())
                        {
                            ExpertSkillsNames = Skills;
                        }
                        MatchRequestsForThisExpertCount= await expertProfileAppService.GetMatchRequestCountForExpertAsync(ExpertID, WantedUser.CityId,cancellationToken);
                        AllCurrentExpertRequests = await expertProfileAppService.GetExpertNotCompeletedRequestsAsync(ExpertID, cancellationToken);
                        AllExpertRequestCount = await expertProfileAppService.GetAllExpertRequestsCountAsync(ExpertID, cancellationToken);
                        AllExpertOfferCount = await expertProfileAppService.GetAllExpertOffersCount(ExpertID, cancellationToken);
                        ExpertComments= await expertProfileAppService.GetExpertCommentsAsync(ExpertID, cancellationToken);
                    }

                }
            }
            return Page();
        }
    }
}
