using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SangaghakAppService.Sangaghak.Pages
{
    public class CustomerProfileAppService : ICustomerProfileAppService
    {
        private readonly IUserBaseService _userBaseService;
        private readonly IRequestService _requestService;
        private readonly IServicePackageService _servicePackageService;
        private readonly ICityService _cityService;
        private readonly UserManager<UserBase> _userManager;
        public CustomerProfileAppService(IUserBaseService userBaseService, IRequestService requestService, IServicePackageService servicePackageService, ICityService cityService, UserManager<UserBase> userManager)
        {
            _userBaseService = userBaseService;
            _requestService = requestService;
            _servicePackageService = servicePackageService;
            _cityService = cityService;
            _userManager = userManager;
        }

        public Task<bool> CheckCustomerHasRequest(int CustomerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<UserBaseSummaryDto> CustomerSummary(int CustomerId, CancellationToken cancellationToken)
        {
            var User = await _userBaseService.GetCustomerSummeryByCustomerId(CustomerId, cancellationToken);
            User.CityName = await _cityService.GetNameOfCity(User.CityId, cancellationToken);
            return User;
        }

        public async Task<int> GetCustomerBalance(int CustomerId, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
            if (user is null) return 0;//یه لاگ اینجا میزنی
            else return user.Balance;
        }

        public async Task<int> GetCustomerCompletedRequestsCount(int CustomerId, CancellationToken cancellationToken)
        {
            return await _requestService.GetCustomerCompletedRequestsCount(CustomerId, cancellationToken);
        }

        public async Task<int> GetCustomerId(int UserId, CancellationToken cancellationToken)
        {
            var User= await _userManager.Users.FirstOrDefaultAsync(x => x.Id == UserId && x.IsDeleted == false);
            if (User == null) return 0;
            return User.CustomerId.Value;
        }

        public async Task<List<RequestDTO>?> GetRequestsByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
        {
            var Requests = await _requestService.GetRequestsByCustomerIdAsync(customerId, cancellationToken);
            if (Requests is null)
            {
                return null;
                //یه لاگ اینجا میزنی
            }
            else
            {
                foreach (var request in Requests)
                {
                    request.ServicePackageTiltle = await _servicePackageService.GetPackageTiltleById(request.ServicePackageId, cancellationToken);
                }
                return Requests;
            }

        }

        public async Task<int> GetUserBalance(int UserId, CancellationToken cancellationToken)
        {
            var User= await _userManager.Users.FirstOrDefaultAsync(x => x.Id == UserId && x.IsDeleted==false);
            if (User == null) return 0;
            return User.Balance;
        }

        public async Task<GetUserBaseForViewPage> UserSummary(int UserId, CancellationToken cancellationToken)
        {
            return await _userBaseService.GetByIdAsync(UserId, cancellationToken);
        }
    }
}
