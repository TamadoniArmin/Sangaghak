using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Data.Repositories;
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
        public async Task<List<City>> GetAllCities(CancellationToken cancellationToken)
        {
            return await _context.Cities.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<City> GetCityById(int id, CancellationToken cancellationToken)
        {
            return await _context.Cities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<City> GetCityByName(string cityName, CancellationToken cancellationToken)
        {
            return await _context.Cities.AsNoTracking().FirstOrDefaultAsync(x => x.Title == cityName, cancellationToken);
        }
        #endregion
    }
}
