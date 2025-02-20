using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IRequestAppService
    {
        #region Create
        public Task<bool> CreateRequestAsync(Request request, CancellationToken cancellationToken);
        #endregion
        #region Read
        public Task<List<Request>> GetRequestsByCustomerIdAsync(int customerId, CancellationToken cancellationToken);
        public Task<List<Request>> GetAllRequestsAsync(CancellationToken cancellationToken);
        public Task<List<Request>> GetRequestBySubCategoryAsync(int subCategoryId, CancellationToken cancellationToken);
        public Task<List<Request>> GetRequestByStatusAsync(RequestStatusEnum status, CancellationToken cancellationToken);
        #endregion
        #region Update
        public Task<bool> UpdateRequestDetailsAsync(Offer offer, int RequestId, CancellationToken cancellationToken);
        public Task<bool> UpdateRequestStatusAsync(int RequestId, RequestStatusEnum requestStatus, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteRequestDetailsAsync(int RequestId, CancellationToken cancellationToken);
        #endregion
    }
}
