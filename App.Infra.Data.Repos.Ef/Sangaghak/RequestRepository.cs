using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
using Azure.Core;
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
                var Request = new App.Domain.Core.Sangaghak.Entities.Requests.Request()
                {
                    Description = request.Description,
                    WantedPrice = request.WantedPrice,
                    Address = request.Address,
                    CityId = request.CityId,
                    CustomerId = request.CustomerId,
                    MaxTime = request.MaxTime,
                    ServicePackageId = request.ServicePackageId,
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
        #region Expert
        public async Task<List<RequestDTO>> GetExpertNotCompeletedRequestsAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _context.Requests
            .Where(r => r.AcceptedOffer != null &&
                        r.AcceptedOffer.ExpertId == ExpertId &&
                        r.Status != RequestStatusEnum.Complited &&
                        r.Status != RequestStatusEnum.Cancelled)
            .Select(x => new RequestDTO()
            {
                Id = x.Id,
                Description = x.Description,
                WantedPrice = x.WantedPrice,
                Address = x.Address,
                CityId = x.CityId,
                CustomerId = x.CustomerId,
                MaxTime = x.MaxTime,
                Status = x.Status,
                SetAt = x.SetAt,
                AcceptedOfferId = x.AcceptedOfferId
            }).ToListAsync(cancellationToken);
        }
        public async Task<List<RequestDTO>> GetAllExpertRequestsAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _context.Requests
            .Where(r => r.AcceptedOffer != null &&
                        r.AcceptedOffer.ExpertId == ExpertId)
            .Select(x => new RequestDTO()
            {
                Id = x.Id,
                Description = x.Description,
                WantedPrice = x.WantedPrice,
                Address = x.Address,
                CityId = x.CityId,
                CustomerId = x.CustomerId,
                MaxTime = x.MaxTime,
                Status = x.Status,
                SetAt = x.SetAt,
                AcceptedOfferId = x.AcceptedOfferId
            }).ToListAsync(cancellationToken);
        }
        public async Task<List<RequestDTO>> GetMatchRequestForExpert(int cityId, List<int> PackagesId, CancellationToken cancellationToken)
        {

            return await _context.Requests
                .Where(r => r.CityId == cityId
                && PackagesId.Contains(r.ServicePackageId)
                && r.IsDeleted == false 
                && r.Status!= RequestStatusEnum.Cancelled
                && r.AcceptedOffer == null
                && (r.AcceptedOfferId == null || r.AcceptedOfferId == 0))
                .Select(x => new RequestDTO
                {
                    Id = x.Id,
                    Description = x.Description,
                    WantedPrice = x.WantedPrice,
                    Address = x.Address,
                    CityId = x.CityId,
                    CustomerId = x.CustomerId,
                    ServicePackageId = x.ServicePackageId,
                    MaxTime = x.MaxTime,
                    SetAt = x.SetAt,
                    Status = x.Status,
                    Images1 = x.ImagePath1,
                    Images2 = x.ImagePath2
                })
                .ToListAsync(cancellationToken);
        }
        public async Task<int> GetMatchRequestForExpertCount(int cityId, List<int> PackagesId, CancellationToken cancellationToken)
        {
            return await _context.Requests
                .Where(r => r.CityId == cityId
                && PackagesId.Contains(r.ServicePackageId)
                && r.IsDeleted == false 
                && r.Status!= RequestStatusEnum.Cancelled
                && r.AcceptedOffer == null
                && (r.AcceptedOfferId == null || r.AcceptedOfferId == 0))
                .CountAsync(cancellationToken);
        }
        public async Task<int> GetAllExpertRequestsCountAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _context.Requests
                .Where(r => r.AcceptedOffer != null &&
                            r.AcceptedOffer.ExpertId == ExpertId)
                .CountAsync(cancellationToken);
        }

        #endregion
        #region Customer
        public async Task<int> GetCustomerCompletedRequestsCount(int CustomerId, CancellationToken cancellationToken)
        {
            return await _context
                .Requests
                .Where(x => x.CustomerId == CustomerId && x.Status == RequestStatusEnum.Complited && x.IsDeleted == false)
                .CountAsync(cancellationToken);
        }
        public async Task<List<RequestDTO>?> GetRequestsByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
        {
            var Result = await _context.Requests.AnyAsync(x => x.CustomerId == customerId && x.IsDeleted == false);
            if (Result == false)
            {
                return null;
            }
            else
            {
                return await _context
                .Requests
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
                    ServicePackageId = x.ServicePackageId,
                    MaxTime = x.MaxTime,
                    Status = x.Status,
                    SetAt = x.SetAt,
                    AcceptedOfferId = x.AcceptedOfferId
                }
                ).ToListAsync(cancellationToken);
            }

        }

        #endregion
        #region General
        public async Task<int> GetRequestPackageIdAsync(int RequestId, CancellationToken cancellationToken)
        {
            var Request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == RequestId && x.IsDeleted == false);
            if (Request == null) return 0;
            else
            {
                return Request.ServicePackageId;
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
        public async Task<int> GetRequestPackageIdByRequestIdAsync(int RequestId, CancellationToken cancellationToken)
        {
            return await _context.Requests
                .AsNoTracking()
                .Where(x => x.Id == RequestId && !x.IsDeleted)
                .Select(x => x.ServicePackageId)
                .FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<RequestDTO?> GetRequestByIdAysnc(int RequestId, CancellationToken cancellationToken)
        {
            var Request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == RequestId && x.IsDeleted == false);
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
                requestDTO.SetAt = Request.SetAt;
                requestDTO.Status = Request.Status;
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
                    ServicePackageId = x.ServicePackageId,
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
           .AsNoTracking()
           .Where(x => x.ServicePackage.Id == subCategoryId && x.IsDeleted == false)
           .Select(x => new RequestDTO()
           {
               Id = x.Id,
               Description = x.Description,
               WantedPrice = x.WantedPrice,
               Address = x.Address,
               CityId = x.CityId,
               CustomerId = x.CustomerId,
               ServicePackageId = x.ServicePackageId,
               MaxTime = x.MaxTime,
               Status = x.Status,
               SetAt = x.SetAt,
               AcceptedOfferId = x.AcceptedOfferId
           }
           ).ToListAsync(cancellationToken);
        }
        #endregion
        #region AdminOnly
        public async Task<int> GetAllRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _context.Requests.Where(x => x.IsDeleted == false).CountAsync(cancellationToken);
        }

        public async Task<int> GetCurrentRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _context.Requests.Where(x => x.Status != RequestStatusEnum.Complited && x.IsDeleted == false).CountAsync(cancellationToken);
        }
        public async Task<int> GetComplitedRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _context.Requests.Where(x => x.Status == RequestStatusEnum.Complited && x.IsDeleted == false).CountAsync(cancellationToken);
        }

        public async Task<int> GetCancelledRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _context.Requests.Where(x => x.Status == RequestStatusEnum.Cancelled && x.IsDeleted == false).CountAsync(cancellationToken);
        }
        #endregion
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
