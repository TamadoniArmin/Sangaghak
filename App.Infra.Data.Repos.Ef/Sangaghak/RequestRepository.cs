using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _context;
        public RequestRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<bool> CreateRequestAsync(Request request)
        {
            var WantedRequest = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Title == request.Title);
            if (WantedRequest == null)
            {
                await _context.Requests.AddAsync(request);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteRequestDetailsAsync(int RequestId)
        {
            var Request = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == RequestId);
            if (Request != null)
            {
                _context.Requests.Remove(Request);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Request>> GetAllRequestsAsync()
        {
            return await _context.Requests.AsNoTracking().ToListAsync();
        }

        public async Task<List<Request>> GetRequestByStatusAsync(RequestStatusEnum status)
        {
            return await _context.Requests.AsNoTracking().Where(x => x.Status == status).ToListAsync();
        }

        public async Task<List<Request>> GetRequestBySubCategoryAsync(int subCategoryId)
        {
            return await _context.Requests.AsNoTracking().Where(x => x.CategoryId == subCategoryId).ToListAsync();
        }

        public async Task<List<Request>> GetRequestsByCustomerIdAsync(int customerId)
        {
            return await _context.Requests.AsNoTracking().Where(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<bool> UpdateRequestDetailsAsync(Offer offer, int RequestId)
        {
            var Request = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == RequestId);
            if (Request != null)
            {
                Request.AcceptedOffer = offer;
                Request.Status = RequestStatusEnum.OfferAccepted;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateRequestStatusAsync(int RequestId, RequestStatusEnum requestStatus)
        {
            var Request = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == RequestId);
            if (Request != null)
            {
                Request.Status = requestStatus;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
