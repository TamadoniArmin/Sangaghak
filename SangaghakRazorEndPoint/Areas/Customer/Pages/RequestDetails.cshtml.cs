using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    public class RequestDetailsModel(IRequestAppService requestAppService, IOfferService offerService) : PageModel
    {
        [BindProperty]
        public RequestDTO Request { get; set; }
        [BindProperty]
        public List<OfferDTO>? Offers { get; set; }
        public async Task<IActionResult> OnGet(int RequestId, CancellationToken cancellationToken)
        {
            Request = await requestAppService.GetRequestByIdAysnc(RequestId, cancellationToken);
            if(Request == null)
            {
                return NotFound("Can not find wanted request!!!");
            }
            Offers = await offerService.GetRequestOffersAsync(RequestId, cancellationToken);
            return Page();
        }
        public async Task<IActionResult> OnDelete(int RequestId,CancellationToken cancellationToken)
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
            return Page();
        }
        public async Task<IActionResult> OnPostRejectOffer(int OfferId, CancellationToken cancellationToken)
        {
            return Page();
        }
    }
}
