using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface ICustomerRepository
    {
        #region Create
        //public Task<bool> CustomerRegisterAsync(string Email, string PhoneNumber, string Password);
        #endregion
        #region Read
        //public Task<bool> LoginCustomerAsync(string Email, string Password);
        public Task<List<Customer>> GetAllCustomerAsync(CancellationToken cancellationToken);
        public Task<Customer> GetCustomerByIdAsync(int id, CancellationToken cancellationToken);
        public Task<Customer> GetCustomerByNameAsync(string name, CancellationToken cancellationToken);
        public Task<int> GetCustomerBalanceAsync(int Customerid, CancellationToken cancellationToken);
        #endregion
        #region Update
        public Task<bool> IncreaseCustomerBalanceAsync(int Money, int Customerid, CancellationToken cancellationToken);

        public Task<bool> DecreaseCustomerBalanceAsync(int Money, int Customerid, CancellationToken cancellationToken);
        public Task<bool> UpdateCustomerDetailsAsync(Customer customer, int CustomerId, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteCustomerAsync(int id, CancellationToken cancellationToken);
        #endregion
    }
}
