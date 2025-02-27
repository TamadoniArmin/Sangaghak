using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.DTOs.BaseEntities;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface ICityRepository
    {
        #region Read
        public Task<List<CityDTO>> GetAllCities(CancellationToken cancellationToken);
        public Task<CityDTO> GetCityById(int id, CancellationToken cancellationToken);
        public Task<CityDTO> GetCityByName(string cityName, CancellationToken cancellationToken);
        public Task<string> GetNameOfCity(int CityId,CancellationToken cancellationToken);
        #endregion
    }
}
