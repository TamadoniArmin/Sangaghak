using System.ComponentModel.DataAnnotations;
using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class UserBaseRepository : IUserBaseRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserBaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> DecreaseBalanceAsync(int UserId, int money, CancellationToken cancellationToken)
        {
            var WantedUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == UserId && x.IsDeleted == false,cancellationToken);
            if (WantedUser == null || WantedUser.Balance >= 0) return false;
            else
            {
                if (WantedUser.Balance<money)
                {
                    return false;
                }
                else
                {
                    WantedUser.Balance-=money;
                    await _appDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
        }

        public async Task<List<GetUserBaseForViewPage>> GetAllAsync(CancellationToken cancellationToken)
        {
            var Result= await _appDbContext
                .Users
                //.AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .Select(x => new GetUserBaseForViewPage()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FullName=x.FirstName+" "+ x.LastName,
                    UserName=x.UserName??string.Empty,
                    Mobile=x.Mobile,
                    Email=x.Email,
                    RegisterAt=x.RegisteredAt,
                    CityId=x.CityId,
                    Role=x.Role,
                    ImagePath=x.ImagePath
                }).ToListAsync(cancellationToken);
            return Result;
        }

        public async Task<int> GetBalanceAsync(int UserId,CancellationToken cancellationToken)
        {
            var WantedUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == UserId,cancellationToken);
            if (WantedUser == null) return -1;
            return WantedUser.Balance;
        }

        public async Task<GetUserBaseForViewPage> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var WantedUser=await _appDbContext.Users.FirstOrDefaultAsync(x=>x.Id == id && x.IsDeleted==false, cancellationToken);
            if (WantedUser == null) return null;
            var User = new GetUserBaseForViewPage()
            {
                Id = WantedUser.Id,
                FirstName = WantedUser.FirstName,
                LastName = WantedUser.LastName,
                FullName=WantedUser.FirstName+ " " + WantedUser.LastName,
                UserName = WantedUser.UserName,
                Mobile = WantedUser.Mobile,
                Email = WantedUser.Email,
                CityId = WantedUser.CityId,
                Role = WantedUser.Role,
                ImagePath = WantedUser.ImagePath
            };
            return User;
        }

        public async Task<GetUserBaseForViewPage> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            var WantedUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.UserName == name && x.IsDeleted == false, cancellationToken);
            if (WantedUser == null) return null;
            var User = new GetUserBaseForViewPage()
            {
                Id = WantedUser.Id,
                FirstName = WantedUser.FirstName,
                LastName = WantedUser.LastName,
                UserName = WantedUser.UserName,
                Mobile = WantedUser.Mobile,
                Email = WantedUser.Email,
                CityId = WantedUser.CityId,
                Role = WantedUser.Role,
                ImagePath = WantedUser.ImagePath
            };
            return User;
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Users.Where(x=>x.IsDeleted==false).CountAsync(cancellationToken);
        }

        public async Task<int> GetCountByRoleAsync(RoleEnum role, CancellationToken cancellationToken)
        {
            return await _appDbContext.Users.Where(x=>x.Role== role && x.IsDeleted==false).CountAsync(cancellationToken);
        }

        public async Task<UserBaseContactInfoDTO> GetCustomerByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken)
        {
            var Customer = await _appDbContext.Users.FirstOrDefaultAsync(x => x.CustomerId == CustomerId && x.IsDeleted == false, cancellationToken);
            if (Customer == null) return null;
            else
            {
                UserBaseContactInfoDTO userBaseContactInfoDTO = new UserBaseContactInfoDTO()
                {
                    FullName = Customer.FirstName + " " + Customer.LastName,
                    Email = Customer.Email,
                    Phone = Customer.PhoneNumber,
                    CityId = Customer.CityId,
                };
                return userBaseContactInfoDTO;
            }
        }

        public async Task<string> GetExpertNameByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            var Expert = await _appDbContext.Users.FirstOrDefaultAsync(x => x.ExpertId == ExpertId && x.IsDeleted == false, cancellationToken);
            if (Expert == null) return string.Empty;
            else
            {
                var ExpertFullName = Expert.FirstName + " " + Expert.LastName;
                return ExpertFullName;
            }
        }

        public async Task<bool> IncreaseBalance(int UserId, int money, CancellationToken cancellationToken)
        {
            var WantedUser= await _appDbContext.Users.FirstOrDefaultAsync(x=>x.Id == UserId && x.IsDeleted==false, cancellationToken);
            if (WantedUser == null) return false;
            WantedUser.Balance += money;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdateUserInfo(UserBaseDTO user, int UserId,CancellationToken cancellationToken)
        {
            var User=await _appDbContext.Users.FirstOrDefaultAsync(x=>x.Id==UserId && x.IsDeleted==false,cancellationToken);
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
    }
}
