using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Requests
{
    public class RequestAppService : IRequestAppService
    {
        private readonly IRequestService _service;
        private readonly ICityService _cityService;
        private readonly IUserBaseService _userBaseService;
        private readonly ICategoryService _categoryService;
        private readonly IOfferService _offerService;
        public RequestAppService(IRequestService requestService,ICityService cityService,IUserBaseService userBaseService,ICategoryService categoryService,IOfferService offerService)
        {
            _service = requestService;
            _cityService = cityService;
            _userBaseService = userBaseService;
            _categoryService = categoryService;
            _offerService = offerService;
        }

        public Task<bool> CreateRequestAsync(GetDataForCreateRequestDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRequestDetailsAsync(int RequestId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RequestDTO>> GetAllRequestsAsync(CancellationToken cancellationToken)
        {
            var Requests= await _service.GetAllRequestsAsync(cancellationToken);
            foreach (var request in Requests)
            {
                request.CityTitle = await _cityService.GetNameOfCity(request.CityId, cancellationToken);
                request.CustomerFullName=await _userBaseService.GetCustomerNameByCustomerIdAsync(request.CustomerId, cancellationToken);
                request.ServicePackageTiltle=await _categoryService.GetSubCategoryNameByIdAysnc(request.ServicePackageId, cancellationToken);
            }
            return Requests;
        }

        public async Task<int> GetAllRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _service.GetAllRequestsCountAsync(cancellationToken);
        }

        public async Task<int> GetCancelledRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _service.GetCancelledRequestsCountAsync(cancellationToken);
        }

        public async Task<int> GetComplitedRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _service.GetComplitedRequestsCountAsync(cancellationToken);
        }

        public async Task<int> GetCurrentRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _service.GetCurrentRequestsCountAsync(cancellationToken);
        }

        public async Task<RequestDTO?> GetRequestByIdAysnc(int RequestId, CancellationToken cancellationToken)
        {
            var WantedRequest= await _service.GetRequestByIdAysnc(RequestId, cancellationToken);
            if (WantedRequest == null) return null;
            else
            {
                var customer= await _userBaseService.GetCustomerSummeryByCustomerId(WantedRequest.CustomerId, cancellationToken);
                if (customer == null) return null;
                else
                {
                    WantedRequest.CustomerFullName= customer.FirstName + " "+ customer.LastName;
                    WantedRequest.CustomerPhone = customer.Mobile;
                    WantedRequest.CustomerEmail = customer.Email;
                    WantedRequest.CityTitle=await _cityService.GetNameOfCity(WantedRequest.CityId,cancellationToken)??string.Empty;
                    if (WantedRequest.AcceptedOfferId == 0 || WantedRequest.AcceptedOfferId == null)
                    {
                        WantedRequest.AcceptedOfferId = 0;
                        WantedRequest.OfferPrice = 0;
                        WantedRequest.ExpertFullName = "---";
                        WantedRequest.ExpertPhone= "-";
                        WantedRequest.ExpertEmail= "-";
                        return WantedRequest;
                    }
                    else
                    {
                        var Offer = await _offerService.GetOfferByIdAsync(WantedRequest.AcceptedOfferId.Value, cancellationToken);
                        WantedRequest.ExpertId = Offer.ExpertId;
                        WantedRequest.OfferPrice = Offer.OfferedPrice;
                        WantedRequest.OfferDate = Offer.OfferedTime;
                        var Expert = await _userBaseService.GetExpertSummeryByExpertId(Offer.ExpertId, cancellationToken);
                        if (Expert == null) return WantedRequest;
                        else
                        {
                            WantedRequest.ExpertFullName = Expert.FirstName + " " + Expert.LastName;
                            WantedRequest.ExpertPhone = Expert.Mobile;
                            WantedRequest.ExpertEmail = Expert.Email;
                            return WantedRequest;
                        }
                    }

                }
            }
        }

        public async Task<List<RequestDTO>> GetRequestByStatusAsync(RequestStatusEnum status, CancellationToken cancellationToken)
        {
            return await _service.GetRequestByStatusAsync(status, cancellationToken);
        }

        public async Task<List<RequestDTO>> GetRequestBySubCategoryAsync(int subCategoryId, CancellationToken cancellationToken)
        {
            return await _service.GetRequestBySubCategoryAsync(subCategoryId, cancellationToken);
        }

        public async Task<List<RequestDTO>?> GetRequestsByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
        {
            return await _service.GetRequestsByCustomerIdAsync(customerId, cancellationToken);
        }

        public Task<bool> UpdateRequestDetailsAsync(int OfferId, int RequestId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRequestStatusAsync(int RequestId, RequestStatusEnum requestStatus, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
