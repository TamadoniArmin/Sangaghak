using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin
{
    public class SeeAllUsersModel(IUserBaseAppService userBaseAppService) : PageModel
    {
        [BindProperty]
        public List<GetUserBaseForViewPage> AllUsers { get; set; }
        public async void OnGet(CancellationToken cancellationToken)
        {
            AllUsers = await userBaseAppService.GetAllUsersAsync(cancellationToken);
        }
    }
}
