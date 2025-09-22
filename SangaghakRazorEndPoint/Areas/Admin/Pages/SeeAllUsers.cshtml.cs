using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin
{
    [Authorize(Roles = ("Admin"))]
    public class SeeAllUsersModel(IUserBaseAppService userBaseAppService) : PageModel
    {
        [BindProperty]
        public List<GetUserBaseForViewPage> AllUsers { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            AllUsers = await userBaseAppService.GetAllUsersAsync(cancellationToken);
        }
        public async Task<IActionResult> OnGetDelete(int UserId, CancellationToken cancellationToken)
        {
            var Result= await userBaseAppService.DeleteUser(UserId, cancellationToken);
            if(Result == IdentityResult.Success)
            {
                return RedirectToPage("SeeAllUsers");
            }
            return RedirectToPage("Index");
        }
    }
}
