using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.Requests
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;
        public RequestService(IRequestRepository requestRepository)
        {
            _repository = requestRepository;
        }
        public async Task<bool> CreateRequestAsync(Request request, CancellationToken cancellationToken)
        {
            return await _repository.CreateRequestAsync(request, cancellationToken);
        }

        public async Task<bool> DeleteRequestDetailsAsync(int RequestId, CancellationToken cancellationToken)
        {
            return await _repository.DeleteRequestDetailsAsync(RequestId, cancellationToken);
        }

        public async Task<List<Request>> GetAllRequestsAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllRequestsAsync(cancellationToken);
        }

        public async Task<List<Request>> GetRequestByStatusAsync(RequestStatusEnum status, CancellationToken cancellationToken)
        {
            return await _repository.GetRequestByStatusAsync(status, cancellationToken);
        }

        public async Task<List<Request>> GetRequestBySubCategoryAsync(int subCategoryId, CancellationToken cancellationToken)
        {
            return await _repository.GetRequestBySubCategoryAsync(subCategoryId , cancellationToken);
        }

        public async Task<List<Request>> GetRequestsByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
        {
            return await _repository.GetRequestsByCustomerIdAsync(customerId, cancellationToken);
        }

        public async Task<bool> UpdateRequestDetailsAsync(Offer offer, int RequestId, CancellationToken cancellationToken)
        {
            return await _repository.UpdateRequestDetailsAsync(offer, RequestId,cancellationToken);
        }

        public async Task<bool> UpdateRequestStatusAsync(int RequestId, RequestStatusEnum requestStatus, CancellationToken cancellationToken)
        {
            return await _repository.UpdateRequestStatusAsync(RequestId, requestStatus, cancellationToken);
        }
    }
}
