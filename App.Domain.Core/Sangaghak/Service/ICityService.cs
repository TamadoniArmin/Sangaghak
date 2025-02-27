using App.Domain.Core.Sangaghak.DTOs.BaseEntities;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;

namespace App.Domain.Core.Sangaghak.Service
{
    public interface ICityService
    {
        #region Read
        public Task<List<CityDTO>> GetAllCities(CancellationToken cancellationToken);
        public Task<CityDTO> GetCityById(int id, CancellationToken cancellationToken);
        public Task<CityDTO> GetCityByName(string cityName, CancellationToken cancellationToken);
        public Task<string> GetNameOfCity(int CityId, CancellationToken cancellationToken);
        #endregion
    }
}
