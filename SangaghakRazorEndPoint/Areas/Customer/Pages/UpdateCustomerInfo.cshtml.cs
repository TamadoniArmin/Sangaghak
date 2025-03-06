using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    public class UpdateCustomerInfoModel(IUserBaseAppService userBaseAppService) : PageModel
    {
        public GetUserBaseForViewPage WantedUser { get; set; }
        public UserBaseDTO UpdatedUserInfo { get; set; }
        public async Task OnGet(int UserId, CancellationToken cancellationToken)
        {
            WantedUser = await userBaseAppService.GetByIdAsync(UserId, cancellationToken);
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var Result = await userBaseAppService.UpdateUserInfoAsync(UpdatedUserInfo, UpdatedUserInfo.Id, cancellationToken);
            if(!Result)
            {

                return Page();
            }
            else
            {
                return RedirectToPage("CustomerProfile");
            }
        }
    }
}
