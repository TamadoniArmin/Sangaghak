using App.Domain.Core.Sangaghak.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Divarcheh.Endpoints.RazorPages.Areas.Account.Pages
{
    public class LogoutModel(SignInManager<UserBase> signInManager) : PageModel
    {
        private readonly SignInManager<UserBase> _signInManager = signInManager;

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();

            return RedirectToPage("Index");
        }

    }
}
