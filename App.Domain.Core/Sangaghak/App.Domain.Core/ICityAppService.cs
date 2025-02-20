using App.Domain.Core.Sangaghak.Entities.BaseEntities;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface ICityAppService
    {
        #region Read
        public Task<List<City>> GetAllCities(CancellationToken cancellationToken);
        public Task<City> GetCityById(int id, CancellationToken cancellationToken);
        public Task<City> GetCityByName(string cityName, CancellationToken cancellationToken);
        #endregion
    }
}
