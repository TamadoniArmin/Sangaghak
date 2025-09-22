using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Users;

namespace SangaghakRazorEndPoint.Areas.Admin.Pages
{
    [Authorize(Roles = ("Admin"))]
    public class SeeAdminProfileModel(IUserBaseAppService userBaseAppService) : PageModel
    {
        [BindProperty]
        public GetUserBaseForViewPage UserInfo { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            int userid = int.Parse(User.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value);
            UserInfo = await userBaseAppService.GetByIdAsync(userid, cancellationToken);
        }
    }
}
