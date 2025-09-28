using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.Requests
{
    public class RequestService : IRequestService
    {
        #region Dependency Injection
        private readonly IRequestRepository _repository;
        public RequestService(IRequestRepository requestRepository)
        {
            _repository = requestRepository;
        }
        #endregion
        #region Create
        public async Task<bool> CreateRequestAsync(GetDataForCreateRequestDto request, CancellationToken cancellationToken)
        {
            return await _repository.CreateRequestAsync(request, cancellationToken);
        }
        #endregion
        #region Read
        public async Task<List<RequestDTO>> GetAllRequestsAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllRequestsAsync(cancellationToken);
        }

        public async Task<int> GetAllRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllRequestsCountAsync(cancellationToken);
        }

        public async Task<int> GetCancelledRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetCancelledRequestsCountAsync(cancellationToken);
        }

        public async Task<int> GetComplitedRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetComplitedRequestsCountAsync(cancellationToken);
        }

        public async Task<int> GetCurrentRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetCurrentRequestsCountAsync(cancellationToken);
        }

        public async Task<int> GetCustomerCompletedRequestsCount(int CustomerId, CancellationToken cancellationToken)
        {
            return await _repository.GetCustomerCompletedRequestsCount(CustomerId, cancellationToken);
        }

        public async Task<RequestDTO?> GetRequestByIdAysnc(int RequestId, CancellationToken cancellationToken)
        {
            return await _repository.GetRequestByIdAysnc(RequestId, cancellationToken);
        }

        public async Task<List<RequestDTO>> GetRequestByStatusAsync(RequestStatusEnum status, CancellationToken cancellationToken)
        {
            return await _repository.GetRequestByStatusAsync(status, cancellationToken);
        }

        public async Task<List<RequestDTO>> GetRequestBySubCategoryAsync(int subCategoryId, CancellationToken cancellationToken)
        {
            return await _repository.GetRequestBySubCategoryAsync(subCategoryId, cancellationToken);
        }

        public async Task<int> GetRequestPackageIdAsync(int RequestId, CancellationToken cancellationToken)
        {
            return await _repository.GetRequestPackageIdAsync(RequestId, cancellationToken);
        }

        public async Task<int> GetRequestCityIdAsync(int RequestId, CancellationToken cancellationToken)
        {
            return await _repository.GetRequestCityIdAsync(RequestId, cancellationToken);
        }

        public async Task<List<RequestDTO>?> GetRequestsByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
        {
            return await _repository.GetRequestsByCustomerIdAsync(customerId, cancellationToken);
        }



        public async Task<List<RequestDTO>> GetExpertNotCompeletedRequestsAsync(List<int> RequestIds, CancellationToken cancellationToken)
        {
            return await _repository.GetExpertNotCompeletedRequestsAsync(RequestIds, cancellationToken);
        }

        public async Task<List<RequestDTO>> GetMatchRequestForExpert(int cityId, List<int> PackagesId, CancellationToken cancellationToken)
        {
            return await _repository.GetMatchRequestForExpert(cityId, PackagesId, cancellationToken);
        }

        public async Task<int> GetMatchRequestForExpertCount(int cityId, List<int> PackagesId, CancellationToken cancellationToken)
        {
            return await _repository.GetMatchRequestForExpertCount(cityId, PackagesId, cancellationToken);
        }

        public async Task<int> GetAllExpertRequestsCountAsync(List<int> RequestIds, CancellationToken cancellationToken)
        {
            return await _repository.GetAllExpertRequestsCountAsync(RequestIds, cancellationToken);
        }

        public async Task<int> GetRequestPackageIdByRequestIdAsync(int RequestId, CancellationToken cancellationToken)
        {
            return await _repository.GetRequestPackageIdByRequestIdAsync(RequestId, cancellationToken);
        }

        public async Task<List<RequestDTO>> GetAllExpertRequestsAsync(List<int> RequestIds, CancellationToken cancellationToken)
        {
            return await _repository.GetAllExpertRequestsAsync(RequestIds, cancellationToken);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateRequestDetailsAsync(int OfferId, int RequestId, CancellationToken cancellationToken)
        {
            return await _repository.UpdateRequestDetailsAsync(OfferId, RequestId, cancellationToken);
        }

        public async Task<bool> UpdateRequestStatusAsync(int RequestId, RequestStatusEnum requestStatus, CancellationToken cancellationToken)
        {
            return await _repository.UpdateRequestStatusAsync(RequestId, requestStatus, cancellationToken);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteRequestDetailsAsync(int RequestId, CancellationToken cancellationToken)
        {
            return await _repository.DeleteRequestDetailsAsync(RequestId, cancellationToken);
        }
        #endregion
    }
}
