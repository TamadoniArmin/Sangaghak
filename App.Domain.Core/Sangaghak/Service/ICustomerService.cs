using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Service
{
    public interface ICustomerService
    {
        #region Delete
        public Task<bool> DeleteCustomerAsync(int id, CancellationToken cancellationToken);
        #endregion
    }
}
