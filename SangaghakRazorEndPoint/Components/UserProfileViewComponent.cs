using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace SangaghakRazorEndPoint.Components
{
    public class UserProfileViewComponent : ViewComponent
    {
        private readonly IUserBaseAppService _userAppService;

        public UserProfileViewComponent(IUserBaseAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userAppService.GetCurrentUserAsync();
            var model = new UserInfoViewModel
            {
                UserId = user.Id,
                FullName = user.FullName,
                ProfileImageUrl = user.ProfileImageUrl,
            };
            return View(model);
        }
    }
}
