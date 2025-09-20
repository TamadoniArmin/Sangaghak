using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Categories;

namespace SangaghakRazorEndPoint.Areas.Expert.Pages
{
    [Authorize]
    public class SeeAllExpertOffersModel(IOfferAppService offerAppService,
        IServicePackageAppService servicePackageAppService) : PageModel
    {
        [BindProperty]
        public List<OfferDTO>? AllExpertsOffer { get; set; }
        [BindProperty]
        public string? PackageTitle { get; set; }
        public async Task<IActionResult> OnGet(int ExpertId, CancellationToken cancellationToken)
        {
            TempData["ExpertId"] = ExpertId;
            AllExpertsOffer = await offerAppService.GetAllExpertOffersByExpertIdAsync(ExpertId, cancellationToken);
            return Page();
        }

        public async Task<IActionResult> OnGetDelete(int offerId, CancellationToken cancellationToken)
        {
            var result = await offerAppService.DeleteOffer(offerId, cancellationToken);
            if (result)
            {
                return RedirectToPage("SeeAllExpertOffers",new { ExpertId = TempData["RequestId"] });
            }
            return RedirectToPage("SeeAllExpertOffers");
        }
    }
}
