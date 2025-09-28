using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.BaseEntities;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.BaseEntities
{
    public class CityService : ICityService
    {
        #region Dependency Injection
        private readonly ICityRepository _cityRepository;
        private readonly IDapperRepository _dapperRepository;
        public CityService(ICityRepository cityRepository,
            IDapperRepository dapperRepository)
        {
            _cityRepository = cityRepository;
            _dapperRepository = dapperRepository;
        }
        #endregion
        #region Read
        public async Task<List<CityDTO>> GetAllCities(CancellationToken cancellationToken)
        {
            return await _dapperRepository.GetAllCities(cancellationToken);
        }

        public async Task<CityDTO> GetCityById(int id, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetCityById(id, cancellationToken);
        }

        public async Task<CityDTO> GetCityByName(string cityName, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetCityByName(cityName, cancellationToken);
        }

        public async Task<string> GetNameOfCity(int CityId, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetNameOfCity(CityId, cancellationToken);
        }
        #endregion
    }
}
