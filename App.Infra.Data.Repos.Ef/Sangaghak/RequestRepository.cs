using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class RequestRepository : IRequestRepository
    {
        #region Dependency Injection
        private readonly AppDbContext _context;
        public RequestRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        #endregion
        #region Create
        public async Task<bool> CreateRequestAsync(Request request,CancellationToken cancellationToken)
        {
            try
            {
                await _context.Requests.AddAsync(request,cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                //اینجا لاگ نیاز داره
                return false;
            }
        }
        #endregion
        #region Read
        public async Task<List<Request>> GetAllRequestsAsync(CancellationToken cancellationToken)
        {
            return await _context.Requests.AsNoTracking().Where(x =>x.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task<List<Request>> GetRequestByStatusAsync(RequestStatusEnum status, CancellationToken cancellationToken)
        {
            return await _context.Requests.AsNoTracking().Where(x => x.Status == status && x.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task<List<Request>> GetRequestBySubCategoryAsync(int subCategoryId, CancellationToken cancellationToken)
        {
            return await _context.Requests.AsNoTracking().Where(x => x.CategoryId == subCategoryId && x.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task<List<Request>> GetRequestsByCustomerIdAsync(int customerId,CancellationToken cancellationToken)
        {
            return await _context.Requests.AsNoTracking().Where(x => x.CustomerId == customerId && x.IsDeleted == false).ToListAsync(cancellationToken);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateRequestDetailsAsync(Offer offer, int RequestId,CancellationToken cancellationToken)
        {
            var Request = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == RequestId,cancellationToken);
            if (Request != null)
            {
                Request.AcceptedOffer = offer;
                Request.Status = RequestStatusEnum.OfferAccepted;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateRequestStatusAsync(int RequestId, RequestStatusEnum requestStatus, CancellationToken cancellationToken)
        {
            var Request = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == RequestId,cancellationToken);
            if (Request != null)
            {
                Request.Status = requestStatus;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteRequestDetailsAsync(int RequestId, CancellationToken cancellationToken)
        {
            var Request = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == RequestId && x.IsDeleted == false,cancellationToken);
            if (Request != null)
            {
                Request.IsDeleted = true;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
    }
}
