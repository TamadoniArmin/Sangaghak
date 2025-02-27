using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.BaseEntities
{
    public class CityAppService : ICityAppService
    {
        private readonly ICityService _cityService;
        public CityAppService(ICityService cityService)
        {
            _cityService = cityService;
        }
        //public async Task<List<City>> GetAllCities(CancellationToken cancellationToken)
        //{
        //    return await _cityService.GetAllCities(cancellationToken);
        //}

        //public async Task<City> GetCityById(int id, CancellationToken cancellationToken)
        //{
        //    return await GetCityById(id, cancellationToken);
        //}

        //public async Task<City> GetCityByName(string cityName, CancellationToken cancellationToken)
        //{
        //    return await _cityService.GetCityByName(cityName, cancellationToken);
        //}
    }
}
