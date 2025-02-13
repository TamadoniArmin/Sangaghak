using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IRequestRepository
    {
        public Task<bool> CreateRequestAsync(Request request);
        public Task<List<Request>> GetRequestsByCustomerIdAsync(int customerId);
        public Task<List<Request>> GetAllRequestsAsync();
        public Task<List<Request>> GetRequestBySubCategoryAsync(int subCategoryId);
        public Task<List<Request>> GetRequestByStatusAsync(RequestStatusEnum status);
        public Task<bool> UpdateRequestDetailsAsync(Offer offer, int RequestId);
        public Task<bool> UpdateRequestStatusAsync(int RequestId, RequestStatusEnum requestStatus);
        public Task<bool> DeleteRequestDetailsAsync(int RequestId);
    }
}
