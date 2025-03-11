using App.Domain.Core.Sangaghak.App.Domain.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace SangaghakRazorEndPoint.Pages
{
    public class LoginModel(IUserBaseAppService userAppService) : PageModel
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
            var Result=await userAppService.Login(Username, Password, true);
            var X= User.Claims;
            var userid = User.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            if(Result==IdentityResult.Success)
            {
                var userRoles = User.FindFirst(ClaimTypes.Role)?.Value;


                if (userRoles != null)
                {
                    switch (userRoles)
                    {
                        case "Admin":
                            return LocalRedirect("/Admin/Index");
                        case "Customer":
                            return LocalRedirect("/Customer/CustomerProfile");
                        case "Expert":
                            return RedirectToAction("Management", new { area = "Expert" });
                        default:
                            return LocalRedirect("/AccessDenied");
                    }
                }

                // اگر نقش کاربر نامعتبر باشد
                return RedirectToPage("/AccessDenied");
            }
            else
            {
                return Page();
            }


        }
    }
}
