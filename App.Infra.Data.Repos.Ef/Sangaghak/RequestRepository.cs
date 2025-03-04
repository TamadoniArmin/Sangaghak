using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Requests;
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
        public async Task<bool> CreateRequestAsync(GetDataForCreateRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var Request = new Request()
                {
                    Description = request.Description,
                    WantedPrice = request.WantedPrice,
                    Address = request.Address,
                    CityId = request.CityId,
                    CustomerId = request.CustomerId,
                    CategoryId = request.CategoryId,
                    MaxTime = request.MaxTime,
                    Status = RequestStatusEnum.WatingForExpertsOffers,
                    SetAt = DateTime.Now,
                };
                await _context.Requests.AddAsync(Request, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception("Exception");
            }
        }
        #endregion
        #region Read
        public async Task<RequestDTO> GetRequestByIdAysnc(int RequestId, CancellationToken cancellationToken)
        {
            var Request=await _context.Requests.FirstOrDefaultAsync(x => x.Id == RequestId && x.IsDeleted==false);
            if (Request == null) return null;
            else
            {
                RequestDTO requestDTO = new RequestDTO();
                requestDTO.Id = Request.Id;
                requestDTO.WantedPrice = Request.WantedPrice;
                requestDTO.Description = Request.Description;
                requestDTO.CityId = Request.CityId;
                requestDTO.MaxTime = Request.MaxTime;
                requestDTO.Address = Request.Address;
                requestDTO.CustomerId = Request.CustomerId;
                requestDTO.AcceptedOfferId = Request.AcceptedOfferId;
                requestDTO.SetAt= Request.SetAt;
                requestDTO.Status= Request.Status;
                return requestDTO;
            }
        }
        public async Task<List<RequestDTO>> GetAllRequestsAsync(CancellationToken cancellationToken)
        {
            return await _context
                .Requests
                .AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .Select(x => new RequestDTO()
                {
                    Id = x.Id,
                    Description = x.Description,
                    WantedPrice = x.WantedPrice,
                    Address = x.Address,
                    CityId = x.CityId,
                    CustomerId = x.CustomerId,
                    CategoryId = x.CategoryId,
                    MaxTime = x.MaxTime,
                    Status = x.Status,
                    SetAt = x.SetAt,
                    AcceptedOfferId = x.AcceptedOfferId
                }
                ).ToListAsync(cancellationToken);
        }

        public async Task<List<RequestDTO>> GetRequestByStatusAsync(RequestStatusEnum status, CancellationToken cancellationToken)
        {
            return await _context
            .Requests
            .AsNoTracking()
            .Where(x => x.Status == status && x.IsDeleted == false)
            .Select(x => new RequestDTO()
            {
                Id = x.Id,
                Description = x.Description,
                WantedPrice = x.WantedPrice,
                Address = x.Address,
                CityId = x.CityId,
                CustomerId = x.CustomerId,
                CategoryId = x.CategoryId,
                MaxTime = x.MaxTime,
                Status = x.Status,
                SetAt = x.SetAt,
                AcceptedOfferId = x.AcceptedOfferId
            }
            ).ToListAsync(cancellationToken);
        }

        public async Task<List<RequestDTO>> GetRequestBySubCategoryAsync(int subCategoryId, CancellationToken cancellationToken)
        {
             return await _context
            .Requests
            .Include(x=>x.Category)
            .AsNoTracking()
            .Where(x => x.Category.Id == subCategoryId && x.IsDeleted == false)
            .Select(x => new RequestDTO()
            {
                Id = x.Id,
                Description = x.Description,
                WantedPrice = x.WantedPrice,
                Address = x.Address,
                CityId = x.CityId,
                CustomerId = x.CustomerId,
                CategoryId = x.CategoryId,
                MaxTime = x.MaxTime,
                Status = x.Status,
                SetAt = x.SetAt,
                AcceptedOfferId = x.AcceptedOfferId
            }
            ).ToListAsync(cancellationToken);
        }

        public async Task<List<RequestDTO>> GetRequestsByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
        {
            return await _context
            .Requests
            .Include (x=>x.CustomerId)
            .AsNoTracking()
            .Where(x => x.Customer.Id == customerId && x.IsDeleted == false)
            .Select(x => new RequestDTO()
            {
                Id = x.Id,
                Description = x.Description,
                WantedPrice = x.WantedPrice,
                Address = x.Address,
                CityId = x.CityId,
                CustomerId = x.CustomerId,
                CategoryId = x.CategoryId,
                MaxTime = x.MaxTime,
                Status = x.Status,
                SetAt = x.SetAt,
                AcceptedOfferId = x.AcceptedOfferId
            }
            ).ToListAsync(cancellationToken);
        }
        public async Task<int> GetAllRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _context.Requests.Where(x=>x.IsDeleted==false).CountAsync(cancellationToken);
        }

        public async Task<int> GetCurrentRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _context.Requests.Where(x=>x.Status!= RequestStatusEnum.Complited && x.IsDeleted==false).CountAsync(cancellationToken);
        }
        public async Task<int> GetComplitedRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _context.Requests.Where(x => x.Status == RequestStatusEnum.Complited && x.IsDeleted == false).CountAsync(cancellationToken);
        }

        public async Task<int> GetCancelledRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _context.Requests.Where(x => x.Status == RequestStatusEnum.Cancelled && x.IsDeleted == false).CountAsync(cancellationToken);
        }
        public async Task<int> GetRequestCategoryIdAsync(int RequestId, CancellationToken cancellationToken)
        {
            var Request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == RequestId && x.IsDeleted == false);
            if (Request == null) return 0;
            else
            {
                return Request.CategoryId;
            }
        }
        public async Task<int> GetRequestCityIdAsync(int RequestId, CancellationToken cancellationToken)
        {
            var Request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == RequestId && x.IsDeleted == false);
            if (Request == null) return 0;
            else
            {
                return Request.CityId;
            }
        }
        #endregion
        #region Update
        public async Task<bool> UpdateRequestDetailsAsync(int OfferId, int RequestId, CancellationToken cancellationToken)
        {
            var Request = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == RequestId, cancellationToken);
            if (Request != null)
            {
                Request.AcceptedOfferId = OfferId;
                Request.Status = RequestStatusEnum.OfferAccepted;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateRequestStatusAsync(int RequestId, RequestStatusEnum requestStatus, CancellationToken cancellationToken)
        {
            var Request = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == RequestId, cancellationToken);
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
            var Request = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == RequestId && x.IsDeleted == false, cancellationToken);
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
