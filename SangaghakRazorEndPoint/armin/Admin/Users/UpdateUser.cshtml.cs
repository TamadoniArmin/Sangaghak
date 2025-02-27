using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.BaseEntities;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Users
{
    public class UpdateUserModel(IUserBaseAppService userBaseAppService, ICityService cityService) : PageModel
    {
        [BindProperty]
        public UserBaseDTO UserToUpdate { get; set; }
        [BindProperty]
        public List<CityDTO> Cities { get; set; }
        public async void OnGet(int UserId,CancellationToken cancellationToken)
        {
            UserToUpdate.Id = UserId;
            Cities = await cityService.GetAllCities(cancellationToken);
        }
        public async Task<IActionResult> OnPost( CancellationToken cancellationToken)
        {
            var Result = await userBaseAppService.UpdateUserInfoAsync(UserToUpdate,UserToUpdate.Id.Value ,cancellationToken);
            if(!Result)
            {
                TempData["Error On Update User Info"] = "موقع آپدیت خطایی رخ داد لطفا با پشتیانی تماس حاصل فرمایید";
                //یه لاگ اینجا بزن
                return RedirectToPage("UpdateUserModel");
            }
            TempData["Succes to Update User Info"] = "پروفایل شما با موفقیت بروزرسانی شد";
            //یه لاگ اینجا بزن
            return RedirectToPage("index");
        }
    }
}
