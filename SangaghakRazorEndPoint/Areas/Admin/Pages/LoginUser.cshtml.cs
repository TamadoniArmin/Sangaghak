using App.Domain.Core.Sangaghak.App.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Users;

namespace SangaghakRazorEndPoint.Areas.Admin.Users
{
    public class LoginUserModel(IUserBaseAppService userAppService) : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public bool RememberMe { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await userAppService.Login(Username, Password, true);
            var userid = User.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return RedirectToPage("Index");
        }
    }
}
