using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Users
{
    public class CustomerAppService : ICustomerAppService
    {
        #region Dependency Injection
        private readonly ICustomerService _customerService;
        public CustomerAppService(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion
    }
}
