using System.ComponentModel;
using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin
{
    public class UserRegisterModel(IUserBaseAppService _userBaseAppService) : PageModel
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
            if(RePassword!=Password)
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


                await _userBaseAppService.Register(userForRegisterDTO, cancellationToken);//این خروجی داره

                return RedirectToPage("Index");
            }
        }
    }
}
