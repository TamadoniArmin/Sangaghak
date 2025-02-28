using App.Domain.Core.Sangaghak.App.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Pages.Account
{
    public class LoginModel (IUserBaseAppService userBaseAppService) : PageModel
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
            await userBaseAppService.Login(Username, Password, true);
            return RedirectToPage("Index");
        }
    }
}
