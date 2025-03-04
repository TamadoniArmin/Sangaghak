using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Requests
{
    public class SeeAllRequestsModel(IRequestAppService requestAppService) : PageModel
    {
        [BindProperty]
        public int AllRequestsCount { get; set; }
        [BindProperty]
        public int CurrentRequestsCount { get; set; }
        [BindProperty]
        public int ComplitedRequestsCount { get; set; }
        [BindProperty]
        public int CancelledRequestsCount { get; set; }
        [BindProperty]
        public List<RequestDTO> AllRequests { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            AllRequestsCount = await requestAppService.GetAllRequestsCountAsync(cancellationToken);
            CurrentRequestsCount= await requestAppService.GetCurrentRequestsCountAsync(cancellationToken);
            ComplitedRequestsCount= await requestAppService.GetComplitedRequestsCountAsync(cancellationToken);
            CancelledRequestsCount=await requestAppService.GetCancelledRequestsCountAsync(cancellationToken);
            AllRequests= await requestAppService.GetAllRequestsAsync(cancellationToken);
        }
    }
}
