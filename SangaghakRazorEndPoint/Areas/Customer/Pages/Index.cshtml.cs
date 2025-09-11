using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Pages;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    [Authorize]
    public class IndexModel(ICustomerProfileAppService customerProfileAppService) : PageModel
    {
        [BindProperty]
        public GetUserBaseForViewPage WantedUser { get; set; }
        [BindProperty]
        public int UserBalance { get; set; }
        [BindProperty]
        public int CompletedRequests { get; set; }
        [BindProperty]
        public bool CustomerHasRequest { get; set; }
        [BindProperty]
        public List<RequestDTO>? UserRequets { get; set; }
        [BindProperty]
        public int AllCustomerRequestsCount { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            int userid = int.Parse(User.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value);
            WantedUser = await customerProfileAppService.UserSummary(userid, cancellationToken);
            UserBalance = await customerProfileAppService.GetUserBalance(userid, cancellationToken);
            int CustomerId = await customerProfileAppService.GetCustomerId(userid, cancellationToken);

            var requests = await customerProfileAppService.GetRequestsByCustomerIdAsync(CustomerId, cancellationToken);
            if (requests is null)
            {
                CustomerHasRequest = false;
                AllCustomerRequestsCount = 0;
                CompletedRequests = 0;
                //یه لاگ اینجا میزنی
            }
            else
            {
                CustomerHasRequest = true;
                AllCustomerRequestsCount = requests.Count();
                UserRequets = requests;
                CompletedRequests = await customerProfileAppService.GetCustomerCompletedRequestsCount(CustomerId, cancellationToken);
            }
        }
    }
}
