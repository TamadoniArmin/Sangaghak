using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IRequestAppService
    {
        #region Create
        public Task<bool> CreateRequestAsync(GetDataForCreateRequestDto request, CancellationToken cancellationToken);
        #endregion
        #region Read
        public Task<RequestDTO?> GetRequestByIdAysnc(int RequestId, CancellationToken cancellationToken);
        public Task<List<RequestDTO>?> GetRequestsByCustomerIdAsync(int customerId, CancellationToken cancellationToken);
        public Task<List<RequestDTO>> GetAllRequestsAsync(CancellationToken cancellationToken);
        public Task<List<RequestDTO>> GetRequestBySubCategoryAsync(int subCategoryId, CancellationToken cancellationToken);
        public Task<List<RequestDTO>> GetRequestByStatusAsync(RequestStatusEnum status, CancellationToken cancellationToken);
        public Task<int> GetAllRequestsCountAsync(CancellationToken cancellationToken);
        public Task<int> GetCurrentRequestsCountAsync(CancellationToken cancellationToken);
        public Task<int> GetComplitedRequestsCountAsync(CancellationToken cancellationToken);
        public Task<int> GetCancelledRequestsCountAsync(CancellationToken cancellationToken);
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
