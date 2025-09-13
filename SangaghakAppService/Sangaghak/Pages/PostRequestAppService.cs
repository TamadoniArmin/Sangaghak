using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangaghakAppService.Sangaghak.Pages
{
    public class PostRequestAppService : IPostRequestAppService
    {
        private readonly IRequestService _requestService;
        private readonly IServicePackageService _servicePackageService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<UserBase> _userManager;
        private readonly ICityService _cityService;
        public PostRequestAppService(IRequestService requestService, IServicePackageService servicePackageService, ICategoryService categoryService, UserManager<UserBase> userManager, ICityService cityService)
        {
            _requestService = requestService;
            _servicePackageService = servicePackageService;
            _categoryService = categoryService;
            _userManager = userManager;
            _cityService = cityService;
        }

        public async Task<List<ServicePackageDTO>> GetAllPackages(CancellationToken cancellationToken)
        {
            var Packages= await _servicePackageService.GetAllAsync(cancellationToken);
            foreach (var package in Packages)
            {
                package.SubCategoryTitle = await _categoryService.GetSubCategoryNameByIdAysnc(package.SubCategoryId, cancellationToken);
            }
            return Packages;
        }

        public async Task<UserBaseDTO> GetLogedInUser(int userId, CancellationToken cancellationToken)
        {
            var User= await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
            if (User == null) return null;
            else
            {
               return new UserBaseDTO
                {
                    Id = User.Id,
                    Email = User.Email,
                    Mobile = User.PhoneNumber ?? string.Empty,
                    UserName = User.UserName ?? string.Empty,
                    CityId = User.CityId,
                    CityName = await _cityService.GetNameOfCity(User.CityId, cancellationToken)??string.Empty,
               };

            }
        }

        public async Task<bool> PostRequest(GetDataForCreateRequestDto requestDto, CancellationToken cancellationToken)
        {
            return await _requestService.CreateRequestAsync(requestDto, cancellationToken);
        }
    }
}
