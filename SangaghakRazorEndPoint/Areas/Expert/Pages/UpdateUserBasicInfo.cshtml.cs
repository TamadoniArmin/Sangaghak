using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.BaseEntities;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Users;
using SangaghakService.Sangaghak.BaseEntities;

namespace SangaghakRazorEndPoint.Areas.Expert.Pages
{
    public class UpdateUserBasicInfoModel(IUserBaseAppService userBaseAppService, 
        ICityService cityService,
        IExpertAppService expertAppService) : PageModel
    {
        [BindProperty]
        public UserBaseDTO UserToUpdate { get; set; }
        [BindProperty]
        public List<CityDTO> Cities { get; set; }
        [BindProperty]
        public GetUserBaseForViewPage PriorUserinfo { get; set; }
        public int WantedUserId { get; set; }
        public async void OnGet(int UserId, CancellationToken cancellationToken)
        {
            WantedUserId = UserId;
            Cities = await cityService.GetAllCities(cancellationToken);
            PriorUserinfo = await userBaseAppService.GetByIdAsync(UserId, cancellationToken);
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var Result = await userBaseAppService.UpdateUserInfoAsync(UserToUpdate, WantedUserId, cancellationToken);
            if (!Result)
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
