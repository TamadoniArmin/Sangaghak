using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.BaseEntities
{
    public class CityAppService : ICityAppService
    {
        #region Dependency Injection
        private readonly ICityService _cityService;
        public CityAppService(ICityService cityService)
        {
            _cityService = cityService;
        }
        #endregion
        #region Create
        #endregion
        #region Read
        #endregion
        #region Update
        #endregion
        #region Delete
        #endregion

    }
}
