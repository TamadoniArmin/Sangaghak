using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Expert.Pages
{
    [Authorize]
    public class SeeAllExpertRequestsModel(IRequestAppService requestAppService) : PageModel
    {
        [BindProperty]
        public List<RequestDTO>? AllExpertRequest { get; set; }
        public async Task<IActionResult> OnGetAsync(int Expertid, CancellationToken cancellationToken)
        {
            AllExpertRequest= await requestAppService.GetAllExpertRequestsAsync(Expertid, cancellationToken);
            return Page();
        }
    }
}
