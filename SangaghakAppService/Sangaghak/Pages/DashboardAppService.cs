using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Pages
{
    public class DashboardAppService(IUserBaseService userBaseService, IRequestService requestService, ICommentService commentService, IOfferService offerService, ICategoryService categoryService, ICityService cityService) : IDashboardAppService
    {
        public async Task<int> GetAllUsersCount(CancellationToken cancellationToken)
        {
            return await userBaseService.GetCountAsync(cancellationToken);
        }

        public async Task<List<GetUserBaseForViewPage>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await userBaseService.GetAllAsync(cancellationToken);
        }

        public async Task<int> GetBalance(int UserId,CancellationToken cancellationToken)
        {
            return await userBaseService.GetBalanceAsync(UserId,cancellationToken);
        }

        public async Task<int> GetEachRoleCount(RoleEnum role,CancellationToken cancellationToken)
        {
            return await userBaseService.GetCountByRoleAsync(role,cancellationToken);
        }

        public async Task<List<RequestDTO>> GetAllRequests(CancellationToken cancellationToken)
        {
            var Requests= await requestService.GetAllRequestsAsync(cancellationToken);
            foreach(var Request in Requests)
            {
                var Customer = await userBaseService.GetCustomerByCustomerIdAsync(Request.CustomerId,cancellationToken);
                Request.CustomerFullName = Customer.FullName;
                Request.CustomerEmail = Customer.Email;
                Request.CustomerPhone = Customer.Phone;
                var Category=await categoryService.GetCategoryByIdAysnc(Request.CategoryId,cancellationToken);
                Request.CategoryTitle = Category.Title;
                var City= await cityService.GetCityById(Request.CityId,cancellationToken);
                Request.CityTitle = City.Title;
                if(Request.AcceptedOfferId!=0 && Request.AcceptedOfferId is not null)
                {
                    Request.ExpertId = await offerService.GetExpertIdByOfferIdAysnc(Request.AcceptedOfferId.Value, cancellationToken);
                    Request.ExpertFullName= await userBaseService.GetExpertNameByExpertIdAsync(Request.ExpertId,cancellationToken);
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
    }
}
