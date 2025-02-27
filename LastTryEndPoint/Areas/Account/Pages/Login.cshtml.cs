using Divarcheh.Domain.AppServices;
using Divarcheh.Domain.Core.Contracts.AppService;
using Divarcheh.Domain.Core.Entities.Configs;
using Divarcheh.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Divarcheh.Endpoints.RazorPages.Areas.Account.Pages
{

    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginModel(SiteSettings siteSettings , IUserAppService userAppService) : PageModel
    {

        [BindProperty]
        public LoginViewModel PageModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await userAppService.Login(PageModel.Username, PageModel.Password,true);
            return RedirectToPage("Login");
        }
    }
}
