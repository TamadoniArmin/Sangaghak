using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface ICustomerProfileAppService
    {
        public Task<UserBaseSummaryDto> CustomerSummary(int CustomerId, CancellationToken cancellationToken);
        public Task<GetUserBaseForViewPage> UserSummary(int UserId, CancellationToken cancellationToken);
        public Task<int> GetCustomerBalance(int CustomerId, CancellationToken cancellationToken);
        public Task<int> GetUserBalance(int UserId, CancellationToken cancellationToken);
        public Task<int> GetCustomerId(int UserId, CancellationToken cancellationToken);
        public Task<bool> CheckCustomerHasRequest(int CustomerId, CancellationToken cancellationToken);
        public Task<List<RequestDTO>?> GetRequestsByCustomerIdAsync(int customerId, CancellationToken cancellationToken);
        public Task<int> GetCustomerCompletedRequestsCount(int CustomerId, CancellationToken cancellationToken);
    }
}
