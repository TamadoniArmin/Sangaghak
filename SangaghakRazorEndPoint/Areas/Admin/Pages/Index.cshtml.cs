using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Pages
{
    //[Authorize(Roles = "Admin")]
    public class IndexModel(IDashboardAppService dashboardAppService) : PageModel
    {
        [BindProperty]
        public List<GetUserBaseForViewPage> Users { get; set; }
        [BindProperty]
        public int AllUsersCount { get; set; }//تعدادکاربران
        [BindProperty]
        public int CustomerCount { get; set; }//تعداد مشتری ها 
        [BindProperty]
        public int ExpertCount { get; set; }//تعداد کارشناسان
        [BindProperty]
        public int Balance { get; set; }//کیف پول
        [BindProperty]
        public int AllRequestsCount { get; set; }//تعداد کل درخواست ها
        [BindProperty]
        public int CurrentRequestsCount { get; set; }//نعداد درخواست های جاری
        [BindProperty]
        public int PendingCommentsCount { get; set; }//تعدادکانت های در انتظار تایید
        [BindProperty]
        public List<RequestDTO> Requests { get; set; }
        public async void OnGet(CancellationToken cancellationToken)
        {
            var data = User;
            Users = await dashboardAppService.GetAllUsersAsync(cancellationToken);
            AllUsersCount = await dashboardAppService.GetAllUsersCount(cancellationToken);
            CustomerCount = await dashboardAppService.GetEachRoleCount(RoleEnum.Customer, cancellationToken);
            ExpertCount = await dashboardAppService.GetEachRoleCount(RoleEnum.Expert, cancellationToken);
            Balance = await dashboardAppService.GetBalance(1, cancellationToken);
            AllRequestsCount = await dashboardAppService.GetAllRequestsCountAsync(cancellationToken);
            CurrentRequestsCount = await dashboardAppService.GetCurrentRequestsCountAsync(cancellationToken);
            PendingCommentsCount = await dashboardAppService.GetPendingCommentCountAsync(cancellationToken);
            Requests = await dashboardAppService.GetAllRequests(cancellationToken);
        }
    }
}
