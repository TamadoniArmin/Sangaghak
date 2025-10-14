using System.ComponentModel.DataAnnotations;
using System.Data;
using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class UserBaseRepository : IUserBaseRepository
    {
        #region Dependency Injection
        private readonly AppDbContext _appDbContext;
        public UserBaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion
        #region Create
        #endregion
        #region Read
        public async Task<List<GetUserBaseForViewPage>> GetAllAsync(CancellationToken cancellationToken)
        {
            var Result = await _appDbContext
                .UserBases
                .Where(x => x.IsDeleted == false)
                .Select(x => new GetUserBaseForViewPage()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FullName = x.FirstName + " " + x.LastName,
                    UserName = x.UserName ?? string.Empty,
                    Mobile = x.Mobile,
                    Email = x.Email,
                    RegisterAt = x.RegisteredAt,
                    CityId = x.CityId,
                    Role = x.Role,
                    ImagePath = x.ImagePath
                }).ToListAsync(cancellationToken);
            return Result;
        }

        public async Task<int> GetBalanceAsync(int UserId, CancellationToken cancellationToken)
        {
            var WantedUser = await _appDbContext.UserBases.FirstOrDefaultAsync(x => x.Id == UserId, cancellationToken);
            if (WantedUser == null) return -1;
            return WantedUser.Balance;
        }

        public async Task<GetUserBaseForViewPage> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .UserBases
                .Where(x => x.Id == id && x.IsDeleted == false)
                .Select(WantedUser => new GetUserBaseForViewPage()
                {
                    Id = WantedUser.Id,
                    FirstName = WantedUser.FirstName,
                    LastName = WantedUser.LastName,
                    FullName = WantedUser.FirstName + " " + WantedUser.LastName,
                    UserName = WantedUser.UserName ?? "نام کاربری برای این کاربر ثبت نشده است",
                    AdminId = WantedUser.AdminId,
                    CustomerId = WantedUser.CustomerId,
                    ExpertId = WantedUser.ExpertId,
                    Mobile = WantedUser.Mobile,
                    Email = WantedUser.Email,
                    CityId = WantedUser.CityId,
                    Role = WantedUser.Role,
                    ImagePath = WantedUser.ImagePath
                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<GetUserBaseForViewPage> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .UserBases
                .Where(x => x.UserName == name && x.IsDeleted == false)
                .Select(WantedUser => new GetUserBaseForViewPage()
                {
                    Id = WantedUser.Id,
                    FirstName = WantedUser.FirstName,
                    LastName = WantedUser.LastName,
                    UserName = WantedUser.UserName ?? string.Empty,
                    Mobile = WantedUser.Mobile,
                    Email = WantedUser.Email,
                    CityId = WantedUser.CityId,
                    Role = WantedUser.Role,
                    ImagePath = WantedUser.ImagePath
                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.UserBases.Where(x => x.IsDeleted == false).CountAsync(cancellationToken);
        }

        public async Task<int> GetCountByRoleAsync(RoleEnum role, CancellationToken cancellationToken)
        {
            return await _appDbContext.UserBases.Where(x => x.Role == role && x.IsDeleted == false).CountAsync(cancellationToken);
        }

        public Task<int> GetCustomerBalance(int CustomerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<UserBaseContactInfoDTO> GetCustomerByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .UserBases
                .Where(x => x.CustomerId == CustomerId && x.IsDeleted == false)
                .Select(Customer => new UserBaseContactInfoDTO()
                {
                    Id = Customer.Id,
                    FullName = Customer.FirstName + " " + Customer.LastName,
                    Email = Customer.Email,
                    Phone = Customer.Mobile,
                    CityId = Customer.CityId,
                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<UserBaseContactInfoDTO> GetExpertByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .UserBases
                .Where(x => x.ExpertId == ExpertId && x.IsDeleted == false)
                .Select(Customer=> new UserBaseContactInfoDTO()
                {
                    Id = Customer.Id,
                    FullName = Customer.FirstName + " " + Customer.LastName,
                    Email = Customer.Email,
                    Phone = Customer.Mobile,
                    CityId = Customer.CityId,
                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<string> GetCustomerNameByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .UserBases
                .Where(x => x.CustomerId == CustomerId && x.IsDeleted == false)
                .Select(x=> x.FirstName+" "+x.LastName)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<UserBaseSummaryDto> GetCustomerSummeryByCustomerId(int CustomerId, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .UserBases
                .Where(x => x.CustomerId == CustomerId && x.IsDeleted == false)
                .Select(User=> new UserBaseSummaryDto()
                {
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    CityId = User.CityId,
                    UserName = User.UserName,
                    Email = User.Email ?? "برای کاربر ایمیلی ثبت نشده است",
                    Mobile = User.Mobile,
                    RegisterAt = User.RegisteredAt,
                    Role = User.Role,
                    ImagePath = User.ImagePath,
                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<string> GetExpertNameByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .UserBases
                .Where(x => x.ExpertId == ExpertId && x.IsDeleted == false)
                .Select(x=> x.FirstName+" "+x.LastName)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<UserBaseSummaryDto> GetExpertSummeryByExpertId(int ExpertId, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .UserBases
                .Where(x => x.ExpertId == ExpertId && x.IsDeleted == false)
                .Select(User=> new UserBaseSummaryDto()
                {
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    CityId = User.CityId,
                    UserName = User.UserName,
                    Email = User.Email,
                    Mobile = User.Mobile,
                    RegisterAt = User.RegisteredAt,
                    Role = User.Role,
                    ImagePath = User.ImagePath,
                }).FirstOrDefaultAsync(cancellationToken);

        }
        public async Task<int> GetCustomerIdByUserId(int UserId, CancellationToken cancellationToken)
        {
            return await _appDbContext.UserBases
                .Where(x => x.Id == UserId && x.IsDeleted == false)
                .Select(x => x.CustomerId.Value)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<int> GetExpertIdIdByUserId(int UserId, CancellationToken cancellationToken)
        {
            return await _appDbContext.UserBases
                .Where(x => x.Id == UserId && x.IsDeleted == false)
                .Select(x=>x.ExpertId.Value)
                .FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<UserBasicInfoDTO?> GetExpertBasicInfoByExpertIdAsync(int expertId, CancellationToken cancellationToken)
        {
            return await _appDbContext.UserBases
                .Where(x => x.ExpertId == expertId && !x.IsDeleted)
                .Select(x => new UserBasicInfoDTO
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FullName = x.FirstName + " " + x.LastName,
                    Email = x.Email,
                    Phone = x.PhoneNumber,
                    CityId = x.CityId,
                    ExpertId = expertId
                }).FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<UserBasicInfoDTO?> GetCustomerBasicInfoByCustomerIdAsync(int customerId, CancellationToken cancellationToken)
        {
            return await _appDbContext.UserBases
                .Where(x => x.CustomerId == customerId && !x.IsDeleted)
                .Select(x => new UserBasicInfoDTO
                {
                    Id = x.Id,
                    UserName = x.UserName ?? string.Empty,
                    FullName = x.FirstName + " " + x.LastName,
                    Email = x.Email ?? string.Empty,
                    Phone = x.PhoneNumber ?? string.Empty,
                    CityId = x.CityId,
                    CustomerId = customerId
                }).FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<UserBasicInfoDTO?> GetAdminBasicInfoByAdminIdAsync(int adminId, CancellationToken cancellationToken)
        {
            return await _appDbContext.UserBases
                .Where(x => x.AdminId == adminId && !x.IsDeleted)
                .Select(x => new UserBasicInfoDTO
                {
                    Id = x.Id,
                    UserName = x.UserName ?? string.Empty,
                    FullName = x.FirstName + " " + x.LastName,
                    Email = x.Email ?? string.Empty,
                    Phone = x.PhoneNumber ?? string.Empty,
                    CityId = x.CityId,
                    AdminId = adminId
                }).FirstOrDefaultAsync(cancellationToken);
        }
        #endregion
        #region Update
        public async Task<(bool Success, string? ErrorMessage)> DecreaseBalanceAsync(int UserId, int money, CancellationToken cancellationToken)
        {
            var WantedUser = await _appDbContext.UserBases
                .FirstOrDefaultAsync(x => x.Id == UserId && x.IsDeleted == false, cancellationToken);

            if (WantedUser == null)
            {
                return (false, "کاربر یافت نشد.");
            }

            if (WantedUser.Balance < money)
            {
                return (false, "موجودی کافی نیست. لطفاً موجودی حساب خود را افزایش دهید.");
            }

            WantedUser.Balance -= money;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return (true, null);
        }

        public async Task<bool> IncreaseBalance(int UserId, int money, CancellationToken cancellationToken)
        {
            var WantedUser = await _appDbContext.UserBases
                .FirstOrDefaultAsync(x => x.Id == UserId && x.IsDeleted == false, cancellationToken);

            if (WantedUser == null)
            {
                return false;
            }

            WantedUser.Balance += money;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdateUserInfo(UserBaseDTO user, int UserId, CancellationToken cancellationToken)
        {
            var User = await _appDbContext.UserBases.FirstOrDefaultAsync(x => x.Id == UserId && x.IsDeleted == false, cancellationToken);
            if (User == null) return false;
            else
            {
                User.FirstName = user.FirstName;
                User.LastName = user.LastName;
                User.CityId = user.CityId;
                User.Mobile = user.Mobile;
                User.ImagePath = user.ImagePath;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteUser(int UserId, CancellationToken cancellationToken)
        {
            var User = await _appDbContext
                .UserBases
                .FirstOrDefaultAsync(x => x.Id == UserId && x.IsDeleted == false);
            if (User == null) return false;
            else
            {
                User.IsDeleted = true;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }

        }

        #endregion
    }
}
