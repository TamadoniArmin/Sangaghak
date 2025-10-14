using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;

namespace SangaghakAppService.Sangaghak.Users
{
    public class UserBaseAppService : IUserBaseAppService
    {
        #region Dependency Injection
        private readonly IUserBaseService _userService;
        private readonly ICityService _cityService;
        private readonly IGeneralService _generalService;
        private readonly UserManager<UserBase> _userManager;
        private readonly SignInManager<UserBase> _signInManager;
        private readonly IPasswordHasher<UserBase> _passwordHasher;
        private readonly ILogger<UserBaseAppService> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserBaseAppService(IUserBaseService userService,
            UserManager<UserBase> userManager,
            SignInManager<UserBase> signInManager,
            IPasswordHasher<UserBase> passwordHasher,
            IGeneralService generalService,
            ICityService cityService,
            ILogger<UserBaseAppService> logger,
            IMemoryCache memoryCache,
            IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _generalService = generalService;
            _cityService = cityService;
            _logger = logger;
            _memoryCache = memoryCache;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion
        #region Create
        public async Task<IdentityResult> Register(UserForRegisterDTO model, CancellationToken cancellationToken)
        {
            string role = string.Empty;

            if (model.ProfileImgFile is not null)
            {
                model.ImagePath = await _generalService.UploadImage(model.ProfileImgFile!, "Profiles", cancellationToken);
            }
            var user = new UserBase
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CityId = model.CityId,
                Email = model.Email,
                Mobile = model.Phone,
                Role = model.Role,
                Balance = 1000000,
                RegisteredAt = DateTime.Now,
                ImagePath = model.ImagePath ?? null
            };

            if (model.Role == RoleEnum.Admin)
            {
                role = "Admin";
            }

            if (model.Role == RoleEnum.Customer)
            {
                role = "Customer";
                user.Customer = new Customer()
                {
                };
            }

            if (model.Role == RoleEnum.Expert)
            {
                role = "Expert";
                user.Expert = new Expert()
                {
                };
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {

                await _userManager.AddToRoleAsync(user, role);


                if (model.Role == RoleEnum.Customer)
                {
                    await _userManager.AddClaimAsync(user, new Claim("CustomerId", user.Customer.Id.ToString()));
                }

                if (model.Role == RoleEnum.Expert)
                {
                    await _userManager.AddClaimAsync(user, new Claim("ExpertId", user.Expert.Id.ToString()));
                }
                if (!model.CreatedByAdmin)
                {
                    await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);
                }
            }
            if (!result.Succeeded)
            {
                _logger.LogWarning("{Time}کاربری با نام کاربری{Usernam} نتوانست ثبتنام کند", DateTime.UtcNow.ToLongTimeString(), user.UserName);
            }
            else if (result.Succeeded)
            {
                _logger.LogInformation("کاربری با نام کاربری {Username} درساعت {Time} با موفقیت ثبتنام کرد", DateTime.UtcNow.ToLongTimeString(), user.UserName);
            }
            return result;
        }

        #endregion
        #region Read
        public async Task<IdentityResult> Login(string username, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, false);
            _logger.Log(logLevel: LogLevel.Warning, "User Logged In");
            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }

        public async Task<int> GetCustomerIdByUserId(int UserId, CancellationToken cancellationToken)
        {
            return await _userService.GetCustomerIdByUserId(UserId, cancellationToken);
        }

        public async Task<int> GetExpertIdIdByUserId(int UserId, CancellationToken cancellationToken)
        {
            return await _userService.GetExpertIdIdByUserId(UserId, cancellationToken);
        }

        public async Task<UserBasicInfoDTO?> GetExpertBasicInfoByExpertIdAsync(int expertId, CancellationToken cancellationToken)
        {
            return await _userService.GetExpertBasicInfoByExpertIdAsync(expertId, cancellationToken);
        }
        public async Task<UserDTO> GetCurrentUserAsync()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            string cacheKey = $"User_{user.Identity.Name}";
            if (!_memoryCache.TryGetValue(cacheKey, out UserDTO userDTO))
            {
                var applicationUser = await _userManager.GetUserAsync(user);
                if (applicationUser == null)
                {
                    return null;
                }

                userDTO = new UserDTO
                {
                    Id = applicationUser.Id,
                    FullName = applicationUser.FirstName + " " + applicationUser.LastName ?? applicationUser.Email ?? "کاربر بدون نام!!!!!",
                    ProfileImageUrl = applicationUser.ImagePath ?? "~/images/Profiles/dummy-avatar.jpg"
                };

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10));
                _memoryCache.Set(cacheKey, userDTO, cacheOptions);
            }

            return userDTO;
        }
        public async Task<UserDTO> GetByIdAsync(int userId)
        {
            var applicationUser = await _userManager.FindByIdAsync(userId.ToString());
            if (applicationUser == null)
            {
                return null;
            }

            return new UserDTO
            {
                Id = applicationUser.Id,
                FullName = applicationUser.FirstName + " " + applicationUser.LastName ?? applicationUser.Email ?? "کاربر بدون نام!!!!!",
                ProfileImageUrl = applicationUser.ImagePath ?? "~/images/Profiles/dummy-avatar.jpg"
            };
        }
        public Task<int> GetBalance(int UserId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserBaseForViewPage> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var User = await _userService.GetByIdAsync(id, cancellationToken);
            User.CityName = await _cityService.GetNameOfCity(User.CityId, cancellationToken);
            return User;
        }

        public Task<int> GetEachRoleCount(RoleEnum customer, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public async Task<List<GetUserBaseForViewPage>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            List<GetUserBaseForViewPage> WantedUsers;
            if (_memoryCache.Get("AllUsers") is not null)
            {
                WantedUsers = _memoryCache.Get<List<GetUserBaseForViewPage>>("AllUsers");
                foreach (var WantedUser in WantedUsers)
                {
                    var cityName = await _cityService.GetNameOfCity(WantedUser.CityId, cancellationToken);
                    WantedUser.CityName = cityName;
                }
            }
            else
            {
                WantedUsers = await _userService.GetAllAsync(cancellationToken);
                foreach (var WantedUser in WantedUsers)
                {
                    var cityName = await _cityService.GetNameOfCity(WantedUser.CityId, cancellationToken);
                    WantedUser.CityName = cityName;
                }
                _memoryCache.Set("AllUsers", WantedUsers,
                    new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromSeconds(10)
                    }
                    );
            }
            return WantedUsers;
        }

        #endregion
        #region Update
        public async Task<IdentityResult> UpdateUserInfo(UserBaseDTO userDto, int userId, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                _logger.LogWarning("کاربری با شناسه {UserId} یافت نشد.", userId);
                return IdentityResult.Failed(new IdentityError { Description = "کاربر یافت نشد." });
            }
            user.UserName = userDto.UserName;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.CityId = userDto.CityId;
            user.Email = userDto.Email;
            user.Mobile = userDto.Mobile;


            if (userDto.ProfileImgFile != null)
            {
                user.ImagePath = await _generalService.UploadImage(userDto.ProfileImgFile, "Profiles", cancellationToken);
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                _logger.LogInformation("کاربر با شناسه {UserId} در ساعت {Time} با موفقیت به‌روزرسانی شد.", userId, DateTime.UtcNow.ToLongTimeString());
            }
            else
            {
                _logger.LogWarning("به‌روزرسانی کاربر با شناسه {UserId} در ساعت {Time} ناموفق بود.", userId, DateTime.UtcNow.ToLongTimeString());
            }

            return result;
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }


        #endregion
        #region Delete
        public async Task<IdentityResult> DeleteUser(int UserId, CancellationToken cancellationToken)
        {
            var StringId = Convert.ToString(UserId);
            var user = await _userManager.FindByIdAsync(StringId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "کاربر یافت نشد." });
            }

            user.IsDeleted = true;
            var result = await _userManager.UpdateAsync(user);
            return result;
        }
        #endregion
    }
}

