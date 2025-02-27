using App.Domain.Core.Sangaghak.App.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Account.Pages
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginModel(IUserBaseAppService userAppService) : PageModel
    {

        [BindProperty]
        public LoginViewModel PageModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await userAppService.Login(PageModel.Username, PageModel.Password, true);
            return RedirectToPage("Login");
        }
    }
}
