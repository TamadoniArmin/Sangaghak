using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Users;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Dependency Injection
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion
        #region Create
        public async Task<bool> CustomerRegisterAsync(string Email, string PhoneNumber, string Password)
        {
            var Customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Email == Email);
            if (Customer == null)
            {
                Customer customer = new Customer();
                customer.Email = Email;
                customer.Phone = PhoneNumber;
                customer.Password = Password;
                customer.RoleId = 2;
                customer.Role.Title = "Customer";
                customer.RegisteredAt = DateTime.Now;
                await _appDbContext.AddAsync(customer);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
        #region Read
        public async Task<bool> LoginCustomerAsync(string Email, string Password)
        {
            var Customer = await _appDbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Email == Email && x.Password == Password && x.IsDeleted == false);
            if (Customer != null)
            {
                return true;
            }
            return false;
        }
        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _appDbContext.Customers.AsNoTracking().Where(x=>x.IsDeleted == false).ToListAsync();
        }

        public async Task<int> GetCustomerBalanceAsync(int Customerid)
        {
            var Customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == Customerid && x.IsDeleted == false);
            if (Customer != null)
            {
                return Customer.Balance;
            }
            return -1;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _appDbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Customer> GetCustomerByNameAsync(string name)
        {
            return await _appDbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == name && x.IsDeleted == false);
        }
        #endregion
        #region Update
        public async Task<bool> DecreaseCustomerBalanceAsync(int Money, int Customerid)
        {
            var Customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == Customerid);
            if (Customer != null)
            {
                if (Customer.Balance < Money)
                {
                    return false;
                }
                else if (Customer.Balance > Money)
                {
                    Customer.Balance -= Money;
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> IncreaseCustomerBalanceAsync(int Money, int Customerid)
        {
            var Customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == Customerid);
            if (Customer != null)
            {
                Customer.Balance += Money;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }



        public async Task<bool> UpdateCustomerDetails(Customer customer, int CustomerId)
        {
            var WantedCustomer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == CustomerId);
            if (WantedCustomer != null)
            {
                WantedCustomer.UserName = customer.UserName;
                WantedCustomer.FirstName = customer.FirstName;
                WantedCustomer.LastName = customer.LastName;
                WantedCustomer.CityId = customer.CityId;
                WantedCustomer.City = customer.City;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var Customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (Customer != null)
            {
                Customer.IsDeleted = true;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
    }
}
