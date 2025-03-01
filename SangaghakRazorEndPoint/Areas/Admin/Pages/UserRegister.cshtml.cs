using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin
{
    public class UserRegisterModel(IUserBaseAppService _userBaseAppService) : PageModel
    {
        [BindProperty]
        public UserForRegisterDTO newUser { get; set; }


        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _userBaseAppService.Register(newUser, cancellationToken);//این خروجی داره
            return RedirectToPage("Index");
        }
    }
}
