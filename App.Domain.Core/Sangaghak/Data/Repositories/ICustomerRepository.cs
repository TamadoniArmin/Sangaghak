using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface ICustomerRepository
    {
        public Task<bool> CustomerRegisterAsync(string Email,string PhoneNumber,string Password);
        public Task<bool> LoginCustomerAsync(string Email, string Password);
        public Task<List<Customer>> GetAllCustomerAsync();
        public Task<Customer> GetCustomerByIdAsync(int id);
        public Task<Customer> GetCustomerByNameAsync(string name);
        public Task<bool> IncreaseCustomerBalanceAsync(int Money, int Customerid);
        public Task<int> GetCustomerBalanceAsync(int Customerid);
        public Task<bool> DecreaseCustomerBalanceAsync(int Money, int Customerid);
        public Task<bool> UpdateCustomerDetails(Customer customer, int CustomerId);
        public Task<bool> DeleteCustomerAsync(int id);
    }
}
