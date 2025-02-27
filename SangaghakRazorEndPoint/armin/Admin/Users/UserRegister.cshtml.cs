using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin
{
    public class UserRegisterModel(IUserBaseAppService _userBaseAppService) : PageModel
    {
        [BindProperty]
        public UserForRegisterDTO UserForRegiter { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _userBaseAppService.Register(UserForRegiter,cancellationToken);//این خروجی داره
            return RedirectToPage("Index");
        }
    }
}
