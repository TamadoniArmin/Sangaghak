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
        public CustomerRepository(AppDbContext appDbContext, CancellationToken cancellationToken)
        {
            _appDbContext = appDbContext;
        }
        #endregion
        #region Read
        public async Task<List<Customer>> GetAllCustomerAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Customers.AsNoTracking().Where(x=>x.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task<int> GetCustomerBalanceAsync(int Customerid, CancellationToken cancellationToken)
        {
            var Customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == Customerid && x.IsDeleted == false,cancellationToken);
            if (Customer != null)
            {
                return Customer.Balance;
            }
            return -1;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false, cancellationToken);
        }

        public async Task<Customer> GetCustomerByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _appDbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == name && x.IsDeleted == false, cancellationToken);
        }
        #endregion
        #region Update
        public async Task<bool> DecreaseCustomerBalanceAsync(int Money, int Customerid, CancellationToken cancellationToken)
        {
            var Customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == Customerid, cancellationToken);
            if (Customer != null)
            {
                if (Customer.Balance < Money)
                {
                    return false;
                }
                else if (Customer.Balance > Money)
                {
                    Customer.Balance -= Money;
                    await _appDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> IncreaseCustomerBalanceAsync(int Money, int Customerid, CancellationToken cancellationToken)
        {
            var Customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == Customerid,cancellationToken);
            if (Customer != null)
            {
                Customer.Balance += Money;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }



        public async Task<bool> UpdateCustomerDetailsAsync(Customer customer, int CustomerId, CancellationToken cancellationToken)
        {
            var WantedCustomer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == CustomerId, cancellationToken);
            if (WantedCustomer != null)
            {
                WantedCustomer.UserName = customer.UserName;
                WantedCustomer.FirstName = customer.FirstName;
                WantedCustomer.LastName = customer.LastName;
                WantedCustomer.CityId = customer.CityId;
                WantedCustomer.City = customer.City;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteCustomerAsync(int id, CancellationToken cancellationToken)
        {
            var Customer = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false, cancellationToken);
            if (Customer != null)
            {
                Customer.IsDeleted = true;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
    }
}
