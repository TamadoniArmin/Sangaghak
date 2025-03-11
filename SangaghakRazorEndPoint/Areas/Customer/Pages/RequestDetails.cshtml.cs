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
        public List<OfferDTO> Offers { get; set; }
        public async Task OnGet(int RequestId, CancellationToken cancellationToken)
        {
            Request = await requestAppService.GetRequestByIdAysnc(RequestId, cancellationToken);
            Offers = await offerService.GetRequestOffersAsync(RequestId, cancellationToken);
        }
    }
}
