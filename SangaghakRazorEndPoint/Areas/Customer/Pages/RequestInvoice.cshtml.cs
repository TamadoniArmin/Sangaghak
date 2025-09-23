using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    [Authorize(Roles = ("Customer"))]
    public class RequestInvoiceModel(IRequestAppService requestAppService) : PageModel
    {
        [BindProperty]
        public RequestDTO? WantedRequest { get; set; }
        [BindProperty]
        public int CompanyProfit { get; set; }
        [BindProperty]
        public int TotalCost { get; set; }

        public async Task<IActionResult> OnGetAsync(int RequestId, CancellationToken cancellationToken)
        {
            WantedRequest = await requestAppService.GetRequestByIdAysnc(RequestId, cancellationToken);
            if (WantedRequest == null)
            {
                return NotFound("Can not find this request!!!");
            }
            TempData["RequestId"] = WantedRequest.Id;
            TempData["ExpertId"] = WantedRequest.ExpertId;
            TempData["CustomerId"] = WantedRequest.CustomerId;
            CompanyProfit = (int)Math.Ceiling(WantedRequest.OfferPrice * 0.1);
            TotalCost = WantedRequest.OfferPrice + CompanyProfit;
            return Page();
        }

        public async Task<IActionResult> OnGetPay(int OfferedPrice, int requestId, CancellationToken cancellationToken)
        {
            var (success, errorMessage) = await requestAppService.PayRequestAysnc(OfferedPrice, requestId, cancellationToken);
            if (success)
            {
                return RedirectToPage("PostComment", new { CustomerId= TempData["CustomerId"], ExpertId= TempData["ExpertId"], RequestId= TempData["RequestId"] });
            }
            else
            {
                TempData["ErrorMessage"] = errorMessage ?? "خطایی در پردازش پرداخت رخ داد.";
                return RedirectToPage("RequestInvoice", new { RequestId = requestId });
            }
        }
    }
}