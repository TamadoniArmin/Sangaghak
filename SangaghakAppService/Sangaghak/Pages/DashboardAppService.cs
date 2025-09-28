using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;
using Connection.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SangaghakAppService.Sangaghak.Pages
{
    public class DashboardAppService : IDashboardAppService
    {
        #region Dependency Injection
        private readonly IUserBaseService _userBaseService;
        private readonly IRequestService _requestService;//requestService
        private readonly ICommentService _commentService;//commentService
        private readonly IOfferService _offerService;//offerService
        private readonly ICityService _cityService;//cityService
        private readonly UserManager<UserBase> _userManager;//userManager
        private readonly IServicePackageService _servicePackageService;//servicePackageService
        public DashboardAppService(IUserBaseService userBaseService,
            IRequestService requestService,
            ICommentService commentService,
            IOfferService offerService,
            ICityService cityService,
            UserManager<UserBase> userManager,
            IServicePackageService servicePackageService)
        {
            _userBaseService = userBaseService;
            _requestService = requestService;
            _commentService = commentService;
            _offerService = offerService;
            _cityService = cityService;
            _userManager = userManager;
            _servicePackageService = servicePackageService;
        }
        #endregion
        #region Create
        #endregion
        #region Read
        public async Task<int> GetAllUsersCount(CancellationToken cancellationToken)
        {
            return await _userManager.Users.AsNoTracking().Where(x => x.IsDeleted == false).CountAsync(cancellationToken);
        }

        public async Task<List<GetUserBaseForViewPage>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userManager.Users
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Select(x => new GetUserBaseForViewPage
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FullName = x.FirstName + " " + x.LastName,
                    UserName = x.UserName ?? string.Empty,
                    Mobile = x.Mobile,
                    Email = x.Email,
                    RegisterAt = x.RegisteredAt,
                    CityId = x.CityId,
                    Role = x.Role,
                    ImagePath = x.ImagePath
                })
                .ToListAsync();

                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public async Task<int> GetBalance(int UserId, CancellationToken cancellationToken)
        {
            var WantedUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == UserId, cancellationToken);
            if (WantedUser == null) return -1;
            return WantedUser.Balance;
        }

        public async Task<int> GetEachRoleCount(RoleEnum role, CancellationToken cancellationToken)
        {
            return await _userManager.Users.AsNoTracking().Where(x => x.Role == role && x.IsDeleted == false).CountAsync();
        }

        public async Task<List<RequestDTO>> GetAllRequests(CancellationToken cancellationToken)
        {
            var Requests = await _requestService.GetAllRequestsAsync(cancellationToken);
            foreach (var Request in Requests)
            {
                var Customer = await _userBaseService.GetCustomerByCustomerIdAsync(Request.CustomerId, cancellationToken);
                Request.CustomerFullName = Customer.FullName ?? string.Empty;
                Request.CustomerEmail = Customer.Email ?? "ایمیلی ثبت نشده است";
                Request.CustomerPhone = Customer.Phone ?? "شماره ای ثبت نشده است";
                Request.CustomerUserId = Customer.Id;
                Request.ServicePackageTiltle = await _servicePackageService.GetPackageTiltleById(Request.ServicePackageId, cancellationToken);
                var City = await _cityService.GetCityById(Request.CityId, cancellationToken);
                Request.CityTitle = City.Title;
                if (Request.AcceptedOfferId != 0 && Request.AcceptedOfferId is not null)
                {
                    Request.ExpertId = await _offerService.GetExpertIdByOfferIdAysnc(Request.AcceptedOfferId.Value, cancellationToken);
                    var wantedExpert = await _userBaseService.GetExpertByExpertIdAsync(Request.ExpertId, cancellationToken);
                    Request.ExpertFullName = wantedExpert.FullName;
                    Request.ExpertEmail = wantedExpert.Email ?? "ایمیلی ثبت نشده است";
                    Request.ExpertPhone = wantedExpert.Phone ?? "شماره ای ثبت نشده است";
                    Request.ExpertUserId = wantedExpert.Id;
                }
            }
            return Requests;
        }

        public async Task<int> GetAllRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _requestService.GetAllRequestsCountAsync(cancellationToken);
        }

        public async Task<int> GetCurrentRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await _requestService.GetCurrentRequestsCountAsync(cancellationToken);
        }

        public async Task<int> GetPendingCommentCountAsync(CancellationToken cancellationToken)
        {
            return await _commentService.GetPendingCommentCountAsync(cancellationToken);
        }

        public async Task<int> GetAllPackagesCountAsync(CancellationToken cancellationToken)
        {
            return await _servicePackageService.GetAllPackageCount(cancellationToken);
        }
        #endregion
        #region Update
        #endregion
        #region Delete
        #endregion
    }
}
