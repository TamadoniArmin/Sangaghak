using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Expert.Pages
{
    [Authorize(Roles = ("Expert"))]
    public class PostOfferForRequestModel(IRequestAppService requestAppService,
        IOfferAppService offerAppService,
        IExpertAppService expertAppService) : PageModel
    {
        [BindProperty]
        public RequestDTO? WantedRequest { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public int Price { get; set; }
        [BindProperty]
        public DateTime OfferedTime { get; set; }


        public async Task<IActionResult> OnGetAsync(int RequestId, int ExpertId,CancellationToken cancellationToken)
        {
            WantedRequest = await requestAppService.GetRequestByIdAysnc(RequestId, cancellationToken);
            if (WantedRequest == null)
            {
                return NotFound("Can not find this request!!!!");
            }
            else
            {
                TempData["ExpertId"] = ExpertId;
                TempData["RequestId"] = RequestId;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            var expertId= Convert.ToInt32(TempData["ExpertId"]);
            var requestId= Convert.ToInt32(TempData["RequestId"]);
            var Offer = new OfferForCreateAndUpdateDTO
            {
                RequestId = requestId,
                ExpertId = expertId,
                OfferedPrice= Price,
                Description= Description,
                OfferedTime= OfferedTime,
            };
            var Result = await offerAppService.CreatOffer(Offer, cancellationToken);
            if (Result)
            {
                return RedirectToPage("SeeAllExpertOffers");
            }
            else
            {
                return RedirectToPage("PostOfferForRequest", new { RequestId = TempData["RequestId"], ExpertId= TempData["ExpertId"] });
            }
        }
    }
}
