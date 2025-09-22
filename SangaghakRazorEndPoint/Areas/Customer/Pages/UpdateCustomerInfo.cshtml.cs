using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.BaseEntities;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakService.Sangaghak.BaseEntities;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    [Authorize(Roles = ("Customer"))]
    public class UpdateCustomerInfoModel(IUserBaseAppService userBaseAppService,
        ICityService cityService) : PageModel
    {
        [BindProperty]
        public UserBaseDTO UserToUpdate { get; set; }
        [BindProperty]
        public List<CityDTO> Cities { get; set; }
        [BindProperty]
        public GetUserBaseForViewPage PriorUserinfo { get; set; }
        public async Task<IActionResult> OnGet(int UserId, CancellationToken cancellationToken)
        {
            TempData["UserId"] = UserId;
            Cities = await cityService.GetAllCities(cancellationToken);
            PriorUserinfo = await userBaseAppService.GetByIdAsync(UserId, cancellationToken);
            if (PriorUserinfo == null)
            {
                TempData["Error"] = "اطلاعات کاربر یافت نشد.";
                return RedirectToPage("/Error");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostUpdateUser(CancellationToken cancellationToken)
        {
            int wantedId = Convert.ToInt32(TempData["UserId"]);
            var Result = await userBaseAppService.UpdateUserInfo(UserToUpdate, wantedId, cancellationToken);
            if (!Result.Succeeded)
            {
                TempData["Error On Update User Info"] = "موقع آپدیت خطایی رخ داد لطفا با پشتیانی تماس حاصل فرمایید";
                //یه لاگ اینجا بزن
                return RedirectToPage("UpdateCustomerInfoModel");
            }
            TempData["Succes to Update User Info"] = "پروفایل شما با موفقیت بروزرسانی شد";
            //یه لاگ اینجا بزن
            return RedirectToPage("index");
        }
    }
}
