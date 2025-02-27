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
        #region Delete
        public async Task<bool> DeleteCustomerAsync(int id, CancellationToken cancellationToken)
        {
            var Customer= await _appDbContext
                .Customers
                .FirstOrDefaultAsync(x => x.Id==id && x.IsDeleted==false,cancellationToken);
            if (Customer == null) return false;
            Customer.IsDeleted = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
        #endregion
    }
}
