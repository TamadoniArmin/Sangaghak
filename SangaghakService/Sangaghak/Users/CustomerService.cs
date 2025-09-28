using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.Users
{
    public class CustomerService : ICustomerService
    {
        #region Dependency Injection
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion
        #region Create
        #endregion
        #region Read
        #endregion
        #region Update
        #endregion
        #region Delete
        public async Task<bool> DeleteCustomerAsync(int id, CancellationToken cancellationToken)
        {
            return await _customerRepository.DeleteCustomerAsync(id, cancellationToken);
        }
        #endregion
    }
}
