using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;

namespace SangaghakAppService.Sangaghak.Users
{
    public class UserBaseAppService : IUserBaseAppService
    {
        private readonly IUserBaseService _userService;
        private readonly ICityService _cityService;
        private readonly IGeneralService _generalService;

        private readonly UserManager<UserBase> _userManager;
        private readonly SignInManager<UserBase> _signInManager;
        private readonly IPasswordHasher<UserBase> _passwordHasher;
        private readonly ILogger<UserBaseAppService> _logger;
        private readonly IMemoryCache _memoryCache;

        public UserBaseAppService(IUserBaseService userService, UserManager<UserBase> userManager, SignInManager<UserBase> signInManager, IPasswordHasher<UserBase> passwordHasher, IGeneralService generalService,ICityService cityService, ILogger<UserBaseAppService> logger, IMemoryCache memoryCache)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _generalService = generalService;
            _cityService = cityService;
            _logger = logger;
            _memoryCache = memoryCache;
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
                var Name = await _cityService.GetNameOfCity(3, cancellationToken);
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

        public async Task<IdentityResult> Register(UserForRegisterDTO model, CancellationToken cancellationToken)
        {
            string role = string.Empty;


            var user = new UserBase
            {
                UserName = model.UserName,
                FirstName=model.FirstName,
                LastName=model.LastName,
                CityId=model.CityId,
                Email = model.Email,
                Mobile = model.Phone,
                Role=model.Role,
                Balance=1000000
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
                if (model.ProfileImgFile is not null)
                {
                    model.ImagePath = await _generalService.UploadImage(model.ProfileImgFile!, "Profiles", cancellationToken);
                }

                await _userManager.AddToRoleAsync(user, role);


                if (model.Role == RoleEnum.Customer)
                {
                    await _userManager.AddClaimAsync(user, new Claim("CustomerId", user.Customer.Id.ToString()));
                }

                if (model.Role == RoleEnum.Expert)
                {
                    await _userManager.AddClaimAsync(user, new Claim("ExpertId", user.Expert.Id.ToString()));
                }

                await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);
            }
            return result;
        }

        public async Task<bool> UpdateUserInfoAsync(UserBaseDTO user, int UserId, CancellationToken cancellationToken)
        {
            return await _userService.UpdateUserInfoAsync(user, UserId, cancellationToken);
        }
        public async Task<IdentityResult> Login(string username, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, false);
            _logger.Log(logLevel: LogLevel.Warning , "User Logged In");
            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }
    }
}
