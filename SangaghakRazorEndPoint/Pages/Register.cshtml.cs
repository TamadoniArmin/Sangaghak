using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace SangaghakRazorEndPoint.Pages
{
    public class RegisterModel(IUserBaseAppService _userBaseAppService) : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string RePassword { get; set; }
        [BindProperty]
        public IFormFile ProfileImgFile { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public RoleEnum Role { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public int CityId { get; set; }


        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if (RePassword != Password)
            {
                return Page();
            }
            else
            {
                UserForRegisterDTO userForRegisterDTO = new UserForRegisterDTO();
                userForRegisterDTO.Email = Email;
                userForRegisterDTO.UserName = UserName;
                userForRegisterDTO.FirstName = FirstName;
                userForRegisterDTO.LastName = LastName;
                userForRegisterDTO.Password = Password;
                userForRegisterDTO.Phone = PhoneNumber;
                userForRegisterDTO.CityId = CityId;
                userForRegisterDTO.Role = Role;
                userForRegisterDTO.ProfileImgFile = ProfileImgFile;


                 var result=await _userBaseAppService.Register(userForRegisterDTO, cancellationToken);//این خروجی داره

                if (result == IdentityResult.Success)
                {
                    var userRoles = User.FindFirst(ClaimTypes.Role)?.Value;


                    if (userRoles != null)
                    {
                        switch (userRoles)
                        {
                            case "Admin":
                                return LocalRedirect("/Admin/Index");
                            case "Customer":
                                return LocalRedirect("/Customer/Index");
                            case "Expert":
                                return LocalRedirect("/Expert/Index");
                            default:
                                return LocalRedirect("/Account/AccessDenied");
                        }
                    }

                    // اگر نقش کاربر نامعتبر باشد
                    return RedirectToPage("/Account/AccessDenied");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}
