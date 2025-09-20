using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.IdentityModel.Tokens;

namespace SangaghakAppService.Sangaghak.Requests
{
    public class RequestAppService : IRequestAppService
    {
        private readonly IRequestService _service;
        private readonly ICityService _cityService;
        private readonly IUserBaseService _userBaseService;
        private readonly ICategoryService _categoryService;
        private readonly IOfferService _offerService;
        private readonly IServicePackageService _packageService;
        public RequestAppService(IRequestService requestService,
            ICityService cityService,
            IUserBaseService userBaseService,
            ICategoryService categoryService,
            IOfferService offerService,
            IServicePackageService servicePackageService)
        {
            _service = requestService;
            _cityService = cityService;
            _userBaseService = userBaseService;
            _categoryService = categoryService;
            _offerService = offerService;
            _packageService = servicePackageService;
        }

        public async Task<bool> CreateRequestAsync(GetDataForCreateRequestDto request, CancellationToken cancellationToken)
        {
            return await _service.CreateRequestAsync(request, cancellationToken);
        }

        public async Task<bool> DeleteRequestDetailsAsync(int RequestId, CancellationToken cancellationToken)
        {
            return await _service.DeleteRequestDetailsAsync(RequestId, cancellationToken);
        }

        public async Task<List<RequestDTO>> GetAllExpertRequestsAsync(int ExpertId, CancellationToken cancellationToken)
        {
            var WantedRequests= await _service.GetAllExpertRequestsAsync(ExpertId, cancellationToken);
            if (!WantedRequests.IsNullOrEmpty())
            {
                foreach(var request in WantedRequests)
                {
                    var customerId = request.CustomerId;
                    var wantedUser = await _userBaseService.GetCustomerBasicInfoByCustomerIdAsync(customerId, cancellationToken);
                    request.CustomerFullName = wantedUser.FullName??string.Empty;
                }
            }
            return WantedRequests;
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
                var packageName = await _packageService.GetPackageTiltleById(WantedRequest.ServicePackageId, cancellationToken);
                if (packageName == null) return null;
                else
                {
                    WantedRequest.ServicePackageTiltle=packageName;
                    var customer = await _userBaseService.GetCustomerSummeryByCustomerId(WantedRequest.CustomerId, cancellationToken);
                    if (customer == null) return null;
                    else
                    {
                        WantedRequest.CustomerFullName = customer.FirstName + " " + customer.LastName;
                        WantedRequest.CustomerPhone = customer.Mobile;
                        WantedRequest.CustomerEmail = customer.Email;
                        WantedRequest.CityTitle = await _cityService.GetNameOfCity(WantedRequest.CityId, cancellationToken) ?? string.Empty;
                        if (WantedRequest.AcceptedOfferId == 0 || WantedRequest.AcceptedOfferId == null)
                        {
                            WantedRequest.AcceptedOfferId = 0;
                            WantedRequest.OfferPrice = 0;
                            WantedRequest.ExpertFullName = "---";
                            WantedRequest.ExpertPhone = "-";
                            WantedRequest.ExpertEmail = "-";
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
        }

        public async Task<List<RequestDTO>> GetRequestByStatusAsync(RequestStatusEnum status, CancellationToken cancellationToken)
        {
            return await _service.GetRequestByStatusAsync(status, cancellationToken);
        }

        public async Task<List<RequestDTO>> GetRequestBySubCategoryAsync(int subCategoryId, CancellationToken cancellationToken)
        {
            return await _service.GetRequestBySubCategoryAsync(subCategoryId, cancellationToken);
        }

        public async Task<int> GetRequestPackageIdByRequestIdAsync(int RequestId, CancellationToken cancellationToken)
        {
            return await _service.GetRequestPackageIdByRequestIdAsync(RequestId, cancellationToken);
        }

        public async Task<List<RequestDTO>?> GetRequestsByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
        {
            return await _service.GetRequestsByCustomerIdAsync(customerId, cancellationToken);
        }

        public async Task<bool> UpdateRequestDetailsAsync(int OfferId, int RequestId, CancellationToken cancellationToken)
        {
            return await _service.UpdateRequestDetailsAsync(OfferId, RequestId, cancellationToken);
        }

        public async Task<bool> UpdateRequestStatusAsync(int RequestId, RequestStatusEnum requestStatus, CancellationToken cancellationToken)
        {
            return await _service.UpdateRequestStatusAsync(RequestId, requestStatus, cancellationToken);
        }
        public async Task<(bool Success, string? ErrorMessage)> PayRequestAysnc(int OfferedPrice, int RequestId, CancellationToken cancellationToken)
        {
            var wantedRequest = await _service.GetRequestByIdAysnc(RequestId, cancellationToken);
            if (wantedRequest == null)
            {
                return (false, "درخواست موردنظر یافت نشد.");
            }

            var Customer = await _userBaseService.GetCustomerBasicInfoByCustomerIdAsync(wantedRequest.CustomerId, cancellationToken);
            var Expert = await _userBaseService.GetExpertBasicInfoByExpertIdAsync(wantedRequest.ExpertId, cancellationToken);
            var CompanyProfit = (int)Math.Ceiling(wantedRequest.OfferPrice * 0.1);
            var TotalCost = wantedRequest.OfferPrice + CompanyProfit;

            var (success, errorMessage) = await _userBaseService.DecreaseBalanceAsync(Customer.Id, TotalCost, cancellationToken);
            if (!success)
            {
                return (false, errorMessage ?? "موجودی کافی نیست.");
            }

            var Result2 = await _userBaseService.IncreaseBalance(Expert.Id, wantedRequest.OfferPrice, cancellationToken);
            if (!Result2)
            {
                return (false, "خطا در افزایش موجودی کارشناس.");
            }

            var Result3 = await _userBaseService.IncreaseBalance(1, CompanyProfit, cancellationToken);
            if (!Result3)
            {
                return (false, "خطا در افزایش موجودی شرکت.");
            }

            var Result4 = await _service.UpdateRequestStatusAsync(RequestId, RequestStatusEnum.Complited, cancellationToken);
            if (!Result4)
            {
                return (false, "خطا در بروزرسانی وضعیت درخواست شما");
            }
            
            return (true, null);
        }
    }
}
