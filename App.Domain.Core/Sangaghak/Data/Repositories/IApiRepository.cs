using App.Domain.Core.Sangaghak.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IApiRepository
    {
        #region Create
        #endregion
        #region Read
        public Task<List<CategoryWithSubCategoriesAndPackagesDTO>> GetAllCategoriesWithSubCategoriesAndPackagesAsync(CancellationToken cancellationToken);
        #endregion
        #region Update
        #endregion
        #region Delete
        #endregion
    }
}
