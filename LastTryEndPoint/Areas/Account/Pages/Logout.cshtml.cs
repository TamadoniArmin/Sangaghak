using Divarcheh.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Divarcheh.Endpoints.RazorPages.Areas.Account.Pages
{
    public class LogoutModel(SignInManager<User> signInManager) : PageModel
    {
        private readonly SignInManager<User> _signInManager = signInManager;

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();

            return RedirectToPage("Index");
        }

    }
}
