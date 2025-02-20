using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Identity;

namespace SangaghakAppService.Sangaghak.Users
{
    public class UserBaseAppService : IUserBaseAppService
    {
        private readonly IUserBaseService _userBaseService;
        private readonly UserManager<UserBase> _userManager;
        private readonly SignInManager<UserBase> _signInManager;
        public UserBaseAppService(IUserBaseService userBaseService,UserManager<UserBase> userManager, SignInManager<UserBase> signInManager)
        {
            _userBaseService = userBaseService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<List<UserBase>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await _userBaseService.GetAllUsersAsync(cancellationToken);
        }
        public async Task<IdentityResult> Login(string UserName, string Password)
        {
            var result = await _signInManager.PasswordSignInAsync(UserName, Password, true, false);
            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }

        public async Task<IdentityResult> Register(UserBase user, string Password, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(user, Password);
            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }
    }
}
