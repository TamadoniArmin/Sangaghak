using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Pages;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    [Authorize]
    public class IndexModel(ICustomerProfileAppService customerProfileAppService) : PageModel
    {
        [BindProperty]
        public GetUserBaseForViewPage WantedUser { get; set; }
        [BindProperty]
        public int UserBalance { get; set; }
        [BindProperty]
        public int CompletedRequests { get; set; }
        [BindProperty]
        public bool CustomerHasRequest { get; set; }
        [BindProperty]
        public List<RequestDTO>? UserRequets { get; set; }
        [BindProperty]
        public int AllCustomerRequestsCount { get; set; }
        [BindProperty]
        public string RequestsTableHtml { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            int userid = int.Parse(User.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value);
            WantedUser = await customerProfileAppService.UserSummary(userid, cancellationToken);
            UserBalance = await customerProfileAppService.GetUserBalance(userid, cancellationToken);
            int customerId = await customerProfileAppService.GetCustomerId(userid, cancellationToken);

            var requests = await customerProfileAppService.GetRequestsByCustomerIdAsync(customerId, cancellationToken);
            AllCustomerRequestsCount = requests?.Count ?? 0;
            CompletedRequests = await customerProfileAppService.GetCustomerCompletedRequestsCount(customerId, cancellationToken);

            // تولید HTML برای جدول درخواست‌ها
            RequestsTableHtml = GenerateRequestsTableHtml(requests);
        }

        private string GenerateRequestsTableHtml(List<RequestDTO>? requests)
        {
            var htmlBuilder = new StringBuilder();

            if (requests?.Any() != true)
            {
                htmlBuilder.AppendLine("<p>هیچ درخواستی ثبت نشده است.</p>");
            }
            else
            {
                htmlBuilder.AppendLine(@"
                    <div class=""table-responsive"">
                        <table class=""table align-middle mb-0 table-hover table-centered"">
                            <thead class=""bg-light-subtle"">
                                <tr>
                                    <th>وضعیت</th>
                                    <th>قیمت خواسته‌شده</th>
                                    <th>تاریخ ثبت</th>
                                    <th>دسته‌بندی</th>
                                    <th>مشاهده</th>
                                </tr>
                            </thead>
                            <tbody>");

                foreach (var request in requests)
                {
                    var (statusDisplay, statusBadgeClass) = request.Status switch
                    {
                        RequestStatusEnum.WatingForExpertsOffers => ("در انتظار پیشنهادات متخصصین", "bg-warning-subtle text-warning"),
                        RequestStatusEnum.WatingForCustomerComfimation => ("در انتظار تأیید مشتری", "bg-warning-subtle text-warning"),
                        RequestStatusEnum.OfferAccepted => ("پیشنهاد پذیرفته شده", "bg-info-subtle text-info"),
                        RequestStatusEnum.JobDone => ("کار انجام شده", "bg-success-subtle text-success"),
                        RequestStatusEnum.WatingForPay => ("در انتظار پرداخت", "bg-warning-subtle text-warning"),
                        RequestStatusEnum.Complited => ("تکمیل شده", "bg-success-subtle text-success"),
                        RequestStatusEnum.Cancelled => ("لغو شده", "bg-danger-subtle text-danger"),
                        _ => (request.Status.ToString(), "bg-warning-subtle text-warning")
                    };

                    htmlBuilder.AppendLine($@"
                        <tr>
                            <td><span class=""badge {HttpUtility.HtmlEncode(statusBadgeClass)} py-1 px-2"">{HttpUtility.HtmlEncode(statusDisplay)}</span></td>
                            <td>{HttpUtility.HtmlEncode(request.WantedPrice.ToString())}</td>
                            <td>{HttpUtility.HtmlEncode(request.SetAt.ToString("yyyy-MM-dd HH:mm:ss"))}</td>
                            <td>{HttpUtility.HtmlEncode(request.ServicePackageTiltle)}</td>
                            <td>
                                <a href=""#!"" class=""btn btn-light btn-sm""><iconify-icon icon=""solar:eye-broken"" class=""align-middle fs-18""></iconify-icon></a>
                            </td>
                        </tr>");
                }

                htmlBuilder.AppendLine(@"
                            </tbody>
                        </table>
                    </div>");
            }

            return htmlBuilder.ToString();
        }
    }
}
