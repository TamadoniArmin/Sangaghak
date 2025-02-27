using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.BaseEntities;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class CityRepository : ICityRepository
    {
        #region Dependency Injection
        private readonly AppDbContext _context;
        public CityRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        #endregion
        #region Read
        public async Task<List<CityDTO>> GetAllCities(CancellationToken cancellationToken)
        {
            var Cities = await _context
            .Cities
            .AsNoTracking()
            .Select(x => new CityDTO
            {
                Id = x.Id,
                Title = x.Title,
            }).ToListAsync(cancellationToken);
            return Cities;
        }

        public async Task<CityDTO> GetCityById(int id, CancellationToken cancellationToken)
        {
            var FindCity= await _context.Cities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (FindCity == null) return null;
            var City = new CityDTO()
            {
                Id = FindCity.Id,
                Title = FindCity.Title,
            };
            return City;
        }

        public async Task<CityDTO> GetCityByName(string cityName, CancellationToken cancellationToken)
        {
            var FindCity = await _context.Cities.AsNoTracking().FirstOrDefaultAsync(x => x.Title == cityName, cancellationToken);
            if (FindCity == null) return null;
            var City = new CityDTO()
            {
                Id = FindCity.Id,
                Title = FindCity.Title,
            };
            return City;
        }

        public async Task<string> GetNameOfCity(int CityId, CancellationToken cancellationToken)
        {
            var city= await _context.Cities.FirstOrDefaultAsync(x=>x.Id == CityId, cancellationToken);
            if(city is null)return string.Empty;//یه لاگ اینجا میزنی
            else return city.Title;
        }
        #endregion
    }
}
