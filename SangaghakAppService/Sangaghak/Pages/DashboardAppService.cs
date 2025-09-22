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
    public class DashboardAppService(IUserBaseService userBaseService, 
        IRequestService requestService, ICommentService commentService, 
        IOfferService offerService, ICategoryService categoryService, 
        ICityService cityService, UserManager<UserBase> userManager,
        IServicePackageService servicePackageService) : IDashboardAppService
    {
        public async Task<int> GetAllUsersCount(CancellationToken cancellationToken)
        {
            return await userManager.Users.AsNoTracking().Where(x => x.IsDeleted == false).CountAsync(cancellationToken);
        }

        public async Task<List<GetUserBaseForViewPage>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await userManager.Users
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
            var WantedUser = await userManager.Users.FirstOrDefaultAsync(x => x.Id == UserId, cancellationToken);
            if (WantedUser == null) return -1;
            return WantedUser.Balance;
        }

        public async Task<int> GetEachRoleCount(RoleEnum role, CancellationToken cancellationToken)
        {
            return await userManager.Users.AsNoTracking().Where(x => x.Role == role && x.IsDeleted == false).CountAsync();
        }

        public async Task<List<RequestDTO>> GetAllRequests(CancellationToken cancellationToken)
        {
            var Requests = await requestService.GetAllRequestsAsync(cancellationToken);
            foreach (var Request in Requests)
            {
                var Customer = await userBaseService.GetCustomerByCustomerIdAsync(Request.CustomerId, cancellationToken);
                Request.CustomerFullName = Customer.FullName??string.Empty;
                Request.CustomerEmail = Customer.Email??"ایمیلی ثبت نشده است";
                Request.CustomerPhone = Customer.Phone??"شماره ای ثبت نشده است";
                Request.CustomerUserId = Customer.Id;
                Request.ServicePackageTiltle = await servicePackageService.GetPackageTiltleById(Request.ServicePackageId, cancellationToken);
                var City = await cityService.GetCityById(Request.CityId, cancellationToken);
                Request.CityTitle = City.Title;
                if (Request.AcceptedOfferId != 0 && Request.AcceptedOfferId is not null)
                {
                    Request.ExpertId = await offerService.GetExpertIdByOfferIdAysnc(Request.AcceptedOfferId.Value, cancellationToken);
                    var wantedExpert= await userBaseService.GetExpertByExpertIdAsync(Request.ExpertId, cancellationToken);
                    Request.ExpertFullName = wantedExpert.FullName;
                    Request.ExpertEmail = wantedExpert.Email?? "ایمیلی ثبت نشده است";
                    Request.ExpertPhone= wantedExpert.Phone?? "شماره ای ثبت نشده است";
                    Request.ExpertUserId = wantedExpert.Id;
                }
            }
            return Requests;
        }

        public async Task<int> GetAllRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await requestService.GetAllRequestsCountAsync(cancellationToken);
        }

        public async Task<int> GetCurrentRequestsCountAsync(CancellationToken cancellationToken)
        {
            return await requestService.GetCurrentRequestsCountAsync(cancellationToken);
        }

        public async Task<int> GetPendingCommentCountAsync(CancellationToken cancellationToken)
        {
            return await commentService.GetPendingCommentCountAsync(cancellationToken);
        }

        public async Task<int> GetAllPackagesCountAsync(CancellationToken cancellationToken)
        {
            return await servicePackageService.GetAllPackageCount(cancellationToken);
        }
    }
}
