using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.BaseEntities
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<List<City>> GetAllCities(CancellationToken cancellationToken)
        {
            return await _cityRepository.GetAllCities(cancellationToken);
        }

        public async Task<City> GetCityById(int id, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetCityById(id, cancellationToken);
        }

        public async Task<City> GetCityByName(string cityName, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetCityByName(cityName, cancellationToken);
        }
    }
}
