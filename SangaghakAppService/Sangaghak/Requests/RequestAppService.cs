using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Requests
{
    public class RequestAppService : IRequestAppService
    {
        private readonly IRequestService _service;
        public RequestAppService(IRequestService requestService)
        {
            _service = requestService;
        }
        public Task<bool> CreateRequestAsync(Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRequestDetailsAsync(int RequestId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Request>> GetAllRequestsAsync(CancellationToken cancellationToken)
        {
            return await _service.GetAllRequestsAsync(cancellationToken);
        }

        public async Task<List<Request>> GetRequestByStatusAsync(RequestStatusEnum status, CancellationToken cancellationToken)
        {
            return await _service.GetRequestByStatusAsync(status, cancellationToken);
        }

        public async Task<List<Request>> GetRequestBySubCategoryAsync(int subCategoryId, CancellationToken cancellationToken)
        {
            return await _service.GetRequestBySubCategoryAsync(subCategoryId, cancellationToken);
        }

        public async Task<List<Request>> GetRequestsByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
        {
            return await _service.GetRequestsByCustomerIdAsync(customerId, cancellationToken);
        }

        public Task<bool> UpdateRequestDetailsAsync(Offer offer, int RequestId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateRequestStatusAsync(int RequestId, RequestStatusEnum requestStatus, CancellationToken cancellationToken)
        {
            return await _service.UpdateRequestStatusAsync(RequestId, requestStatus, cancellationToken);
        }
    }
}
