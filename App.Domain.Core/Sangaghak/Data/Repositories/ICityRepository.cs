using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface ICityRepository
    {
        #region Read
        public Task<List<City>> GetAllCities();
        public Task<City> GetCityById(int id);
        public Task<City> GetCityByName(string cityName);
        #endregion
    }
}
