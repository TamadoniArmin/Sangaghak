using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SangaghakWebApiEndPoint.WebFramework.ApiHelper;

namespace SangaghakWebApiEndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserBaseAppService userBaseAppService) : ControllerBase
    {
        [HttpGet("Get-all-Users")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var allUsers= await userBaseAppService.GetAllUsersAsync(cancellationToken);
            var result = new ApiResult<List<GetUserBaseForViewPage>, int, int>
            {
                IsSuccess = true,
                Massage = "عملیات با موفقیت انجام شد",
                Result1 = allUsers
            };
            return Ok(result);
        }

        [HttpPost("User-Register")]
        public async Task<IdentityResult> Register(UserForRegisterDTO model, CancellationToken cancellationToken)
        {
            return await userBaseAppService.Register(model, cancellationToken);
        }
    }
}
