using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    [Authorize(Roles = ("Customer"))]
    public class RequestDetailsModel(IRequestAppService requestAppService, IOfferService offerService) : PageModel
    {
        [BindProperty]
        public RequestDTO Request { get; set; }
        [BindProperty]
        public List<OfferDTO>? Offers { get; set; }
        public async Task<IActionResult> OnGet(int RequestId, CancellationToken cancellationToken)
        {
            TempData["RequestId"]= RequestId;
            Request = await requestAppService.GetRequestByIdAysnc(RequestId, cancellationToken);
            if(Request == null)
            {
                return NotFound("Can not find wanted request!!!");
            }
            Offers = await offerService.GetRequestOffersAsync(RequestId, cancellationToken);
            return Page();
        }
        public async Task<IActionResult> OnGetDelete(int RequestId,CancellationToken cancellationToken)
        {
            var Result  = await requestAppService.DeleteRequestDetailsAsync(RequestId, cancellationToken);
            if (Result)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAcceptOffer(int requestid, int offerId,CancellationToken cancellationToken)
        {
            var Result1= await requestAppService.UpdateRequestDetailsAsync(requestid, offerId, cancellationToken);
            if (!Result1)
            { 
                return BadRequest("بروزرسانی این درخواست با خطا مواجه شد افر"); 
            }
            else
            {
                var Result2 = await requestAppService.UpdateRequestStatusAsync(requestid, App.Domain.Core.Sangaghak.Enum.RequestStatusEnum.OfferAccepted, cancellationToken);
                if (!Result2)
                {
                    return BadRequest("بروزرسانی این درخواست با خطا مواجه شد");
                }
                else
                {
                    var Result3 = await offerService.UpdateOfferStatusByOfferIdAysnc(offerId, cancellationToken);
                }
            }          
            return RedirectToPage("RequestDetails", new { RequestId = TempData["RequestId"] });
        }
    }
}
