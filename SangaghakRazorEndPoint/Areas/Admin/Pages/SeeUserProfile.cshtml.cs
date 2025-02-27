using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Users
{
    public class SeeUserProfileModel(IUserBaseAppService userBaseAppService) : PageModel
    {
        [BindProperty]
        public GetUserBaseForViewPage UserInfo { get; set; }
        public async void OnGet(int UserId,CancellationToken  cancellationToken)
        {
            UserInfo = await userBaseAppService.GetByIdAsync(UserId, cancellationToken);
        }
    }
}
