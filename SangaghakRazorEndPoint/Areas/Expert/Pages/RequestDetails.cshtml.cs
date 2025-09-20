using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace SangaghakRazorEndPoint.Areas.Expert.Pages
{
    public class RequestDetailsModel(IRequestAppService requestAppService) : PageModel
    {
        public RequestDTO? Request { get; set; }
        public async Task<IActionResult> OnGet(int RequestId, CancellationToken cancellationToken)
        {
            Request = await requestAppService.GetRequestByIdAysnc(RequestId, cancellationToken);
            if (Request == null)
            {
                return NotFound("Can not Find this request");
            }
            else
            {
                return Page();
            }
        }
    }
}
