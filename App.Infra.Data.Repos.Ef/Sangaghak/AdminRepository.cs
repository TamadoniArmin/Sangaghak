using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Users;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class AdminRepository : IAdminRepository
    {
        #region Dependency Injection
        private readonly AppDbContext _context;
        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion
        #region Create
        //public async Task<bool> RegisterAdminAsync(string Email, string PhoneNumber, string Password)
        //{
        //    try
        //    {
        //        UserBase userBase = new UserBase();
        //        userBase.Email = Email;
        //        userBase.Password = Password;
        //        userBase.Phone = PhoneNumber;
        //        userBase.RoleId = 1;
        //        userBase.Role.Title = "Admin";
        //        userBase.RegisteredAt = DateTime.Now;
        //        await _context.Users.AddAsync(userBase);//پرسیده شود برای ای سینک
        //        await _context.SaveChangesAsync();//برای ای سینک پرسیده شود
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }

        //}
        #endregion
        #region Read
        public async Task<Admin> GetAdmin(int AdminId, CancellationToken cancellationToken)
        {
            return await _context.Admins.FirstOrDefaultAsync(x => x.Id == AdminId && x.Role.Title == "Admin" && x.IsDeleted==false , cancellationToken);
        }

        public async Task<int> GetAdminBalanceAsync(int AdminId, CancellationToken cancellationToken)
        {
            var Admin = await _context.Users.FirstOrDefaultAsync(x => x.Id == AdminId,cancellationToken);
            if (Admin != null)
            {
                if (!Admin.IsDeleted)
                {
                    return Admin.Balance;
                }
            }
            return -1;
        }

        //public async Task<bool> LoginAdminAsync(string Email, string Password)
        //{
        //    var Admin = await _context.Users.FirstOrDefaultAsync(x => x.Email == Email && x.Password == Password);
        //    if (Admin != null)
        //    {
        //        if (!Admin.IsDeleted)
        //        {
        //            return true;
        //        }   
        //    }
        //    return false;
        //}
        #endregion
        #region Update
        public async Task<bool> IncreaseAdminBalanceAsync(int Money, int AdminId, CancellationToken cancellationToken)
        {
            var Admin = await _context.Users.FirstOrDefaultAsync(y => y.Id == AdminId,cancellationToken);
            if (Admin != null)
            {
                Admin.Balance += Money;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateAdminInformationAsync(UserBase admin, int AdminId, CancellationToken cancellationToken)
        {
            var Admin = await _context.Users.FirstOrDefaultAsync(x => x.Id == AdminId, cancellationToken);
            if (Admin != null)
            {
                Admin.UserName = admin.UserName;
                Admin.Password = admin.Password;
                Admin.Phone = admin.Phone;
                Admin.FirstName = admin.FirstName;
                Admin.LastName = admin.LastName;
                Admin.Email = admin.Email;
                Admin.CityId = admin.CityId;
                Admin.City = admin.City;
                Admin.Balance = admin.Balance;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
    }
}
