﻿using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IRequestRepository
    {
        #region Create
        public Task<bool> CreateRequestAsync(GetDataForCreateRequestDto request, CancellationToken cancellationToken);
        #endregion
        #region Read
        public Task<RequestDTO> GetRequestByIdAysnc(int RequestId,CancellationToken cancellationToken);
        public Task<List<RequestDTO>> GetRequestsByCustomerIdAsync(int customerId, CancellationToken cancellationToken);
        public Task<List<RequestDTO>> GetAllRequestsAsync(CancellationToken cancellationToken);
        public Task<List<RequestDTO>> GetRequestBySubCategoryAsync(int subCategoryId, CancellationToken cancellationToken);
        public Task<List<RequestDTO>> GetRequestByStatusAsync(RequestStatusEnum status, CancellationToken cancellationToken);
        public Task<int> GetAllRequestsCountAsync(CancellationToken cancellationToken);
        public Task<int> GetCurrentRequestsCountAsync(CancellationToken cancellationToken);
        public Task<int> GetComplitedRequestsCountAsync(CancellationToken cancellationToken);
        public Task<int> GetCancelledRequestsCountAsync(CancellationToken cancellationToken);
        public Task<int> GetRequestCategoryIdAsync(int RequestId, CancellationToken cancellationToken);
        public Task<int> GetRequestCityIdAsync(int RequestId, CancellationToken cancellationToken);
        public Task<int> GetCustomerCompletedRequestsCount(int CustomerId, CancellationToken cancellationToken);
        #endregion
        #region Update
        public Task<bool> UpdateRequestDetailsAsync(int OfferId, int RequestId, CancellationToken cancellationToken);
        public Task<bool> UpdateRequestStatusAsync(int RequestId, RequestStatusEnum requestStatus, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteRequestDetailsAsync(int RequestId, CancellationToken cancellationToken);
        #endregion
    }
}
