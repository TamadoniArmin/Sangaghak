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
        public async void OnGet(CancellationToken  cancellationToken)
        {
            int userid = int.Parse(User.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value);
            UserInfo = await userBaseAppService.GetByIdAsync(userid, cancellationToken);
        }
    }
}
