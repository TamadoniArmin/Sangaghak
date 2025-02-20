using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.Users
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<bool> DecreaseCustomerBalanceAsync(int Money, int Customerid, CancellationToken cancellationToken)
        {
            return await _customerRepository.DecreaseCustomerBalanceAsync(Money, Customerid, cancellationToken);
        }

        public async Task<bool> DeleteCustomerAsync(int id,CancellationToken cancellationToken)
        {
            return await _customerRepository.DeleteCustomerAsync(id, cancellationToken);
        }

        public async Task<List<Customer>> GetAllCustomerAsync(CancellationToken cancellationToken)
        {
            return await _customerRepository.GetAllCustomerAsync(cancellationToken);
        }

        public async Task<int> GetCustomerBalanceAsync(int Customerid, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerBalanceAsync(Customerid, cancellationToken);
        }

        public async Task<Customer> GetCustomerByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerByIdAsync(id, cancellationToken);
        }

        public async Task<Customer> GetCustomerByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerByNameAsync(name, cancellationToken);
        }

        public async Task<bool> IncreaseCustomerBalanceAsync(int Money, int Customerid, CancellationToken cancellationToken)
        {
            return await _customerRepository.IncreaseCustomerBalanceAsync(Money, Customerid, cancellationToken);
        }

        public async Task<bool> UpdateCustomerDetailsAsync(Customer customer, int CustomerId, CancellationToken cancellationToken)
        {
            return await _customerRepository.UpdateCustomerDetailsAsync(customer, CustomerId, cancellationToken);  
        }
    }
}
