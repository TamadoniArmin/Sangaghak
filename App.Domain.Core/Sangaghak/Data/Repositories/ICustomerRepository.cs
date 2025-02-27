using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface ICustomerRepository
    {
        #region Delete
        public Task<bool> DeleteCustomerAsync(int id, CancellationToken cancellationToken);
        #endregion
    }
}
