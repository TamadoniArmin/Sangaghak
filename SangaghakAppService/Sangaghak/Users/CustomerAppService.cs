using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Users
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        public CustomerAppService(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public Task<bool> DecreaseCustomerBalanceAsync(int Money, int Customerid, CancellationToken cancellationToken)
        {
            //int CurrentMoney=await GetCustomerBalanceAsync(Customerid);
            //if (CurrentMoney==0 || CurrentMoney<Money)
            //{
            //    return false;
            //    //یک لاگ اینجا میخواهیم
            //}
            //else
            //{

            //}
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomerAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAllCustomerAsync(CancellationToken cancellationToken)
        {
            return await _customerService.GetAllCustomerAsync(cancellationToken);
        }

        public async Task<int> GetCustomerBalanceAsync(int Customerid, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomerBalanceAsync(Customerid, cancellationToken);
        }

        public async Task<Customer> GetCustomerByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomerByIdAsync(id, cancellationToken);
        }

        public async Task<Customer> GetCustomerByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomerByNameAsync(name, cancellationToken);
        }

        public async Task<bool> IncreaseCustomerBalanceAsync(int Money, int Customerid, CancellationToken cancellationToken)
        {
            return await _customerService.IncreaseCustomerBalanceAsync(Money, Customerid,cancellationToken);
        }

        public async Task<bool> UpdateCustomerDetailsAsync(Customer customer, int CustomerId, CancellationToken cancellationToken)
        {
            return await _customerService.UpdateCustomerDetailsAsync(customer, CustomerId, cancellationToken);
        }
    }
}
