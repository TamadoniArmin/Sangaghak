using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Expert.Pages
{
    [Authorize(Roles =("Expert"))]
    public class SeeListOfRelatedRequestsModel(IExpertAppService expertAppService) : PageModel
    {
        [BindProperty]
        public List<RequestDTO>? AllRelatedRequest { get; set; }
        public async Task<IActionResult> OnGetAsync(int expertId, int CityId,CancellationToken cancellationToken)
        {
            AllRelatedRequest = await expertAppService.GetMathRequestForExpertInfo(expertId,CityId,cancellationToken);
            return Page();
        }
    }
}
