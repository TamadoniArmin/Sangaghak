using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    public class CustomerProfileModel(ICustomerProfileAppService customerProfileAppService) : PageModel
    {
        [BindProperty]
        public UserBaseSummaryDto WantedUser { get; set; }
        [BindProperty]
        public int UserBalance { get; set; }
        [BindProperty]
        public int CompletedRequests { get; set; }
        [BindProperty]
        public List<RequestDTO> UserRequets { get; set; }
        [BindProperty]
        public int AllCustomerRequestsCount { get; set; }
        public async Task OnGet(int CustomerId,CancellationToken cancellationToken)
        {
            WantedUser = await customerProfileAppService.CustomerSummary(CustomerId, cancellationToken);
            UserBalance = await customerProfileAppService.GetCustomerBalance(CustomerId, cancellationToken);
            CompletedRequests = await customerProfileAppService.GetCustomerCompletedRequestsCount(CustomerId, cancellationToken);
            var requests = await customerProfileAppService.GetRequestsByCustomerIdAsync(CustomerId, cancellationToken);
            AllCustomerRequestsCount = requests.Count();
            UserRequets = requests;

        }
    }
}
