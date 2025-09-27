using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SangaghakWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly  _userBaseAppService;

        public AccountController(IUserBaseAppService userBaseAppService)
        {
            _userBaseAppService = userBaseAppService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterApiDto model, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // اگر ورودی نامعتبر باشد
            }

            // اگر از UserForRegisterDTO استفاده می‌کنید، آن را مپ کنید
            var userForRegister = new UserForRegisterDTO
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                Role = model.Role,
                Password = model.Password,
                CityId = model.CityId,
                CreatedByAdmin = model.CreatedByAdmin, // یا false ثابت
                ProfileImgFile = null, // نادیده گرفته می‌شود
                ImagePath = null // نادیده گرفته می‌شود
            };

            // فراخوانی متد Register از سرویس
            var result = await _userBaseAppService.Register(userForRegister, cancellationToken);

            if (result.Succeeded)
            {
                // می‌توانید توکن JWT یا چیزی برگردانید، اما فعلاً ساده نگه داریم
                return Ok(new { Message = "ثبت‌نام موفق", UserId = /* اگر نیاز باشد، از result بگیرید */ });
            }
            else
            {
                return BadRequest(result.Errors); // خطاهای Identity را برگردانید
            }
        }
    }
}
}
