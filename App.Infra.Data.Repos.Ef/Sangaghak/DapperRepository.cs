using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.BaseEntities;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class DapperRepository : IDapperRepository
    {
        #region Dependency Injection
        private readonly string _connectionString;
        private readonly ILogger<DapperRepository> _logger;

        public DapperRepository(ILogger<DapperRepository> logger)
        {
            _connectionString = "Server=.,1433;Initial Catalog=Sangaghak;User ID=sa;Password=1234;TrustServerCertificate=true";
            _logger = logger;
        }
        #endregion

        #region Read
        public async Task<List<ServicePackageDTO>> GetAllServicePackagesAsync(CancellationToken cancellationToken)
        {
            const string checkQuery = "SELECT COUNT(*) FROM Packages WHERE IsDeleted = 0";
            const string sql = @"
            SELECT Id, Title AS Title, Description, MinPrice, SubCategoryId, ImagePath
            FROM Packages
            WHERE IsDeleted = 0";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);
                var count = await connection.ExecuteScalarAsync<int>(checkQuery, cancellationToken);
                if (count == 0)
                {
                    return null;
                }

                var packages = await connection.QueryAsync<ServicePackageDTO>(sql, cancellationToken);
                return packages.AsList();//AsList برسی شود
            }
        }

        public async Task<List<CategoryDTO>> GetAllCategories(CancellationToken cancellationToken)
        {
            try
            {
                const string sql = @"
                    SELECT 
                        Id, 
                        Title, 
                        Description, 
                        ImagePath, 
                        (SELECT COUNT(*) FROM Categories sc WHERE sc.ParentId = c.Id AND sc.IsDeleted = 0) AS SubCategoryCount
                    FROM Categories c
                    WHERE c.IsDeleted = 0";

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync(cancellationToken);
                    var categories = await connection.QueryAsync<CategoryDTO>(sql, cancellationToken);
                    return categories.AsList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all categories");
                throw;
            }
        }

        public async Task<List<CityDTO>> GetAllCities(CancellationToken cancellationToken)
        {
            try
            {
                const string sql = "SELECT Id, Title FROM Cities";

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync(cancellationToken);
                    var cities = await connection.QueryAsync<CityDTO>(sql, cancellationToken);
                    return cities.AsList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all cities");
                throw;
            }
        }

        public async Task<List<SubCategoryDTO>> GetAllSubCategories(CancellationToken cancellationToken)
        {
            _logger.LogInformation("ادمین تلاش کرد زیر کتگوری ها را بخواند");

            const string sql = @"
            SELECT Id, Title, Description, ImagePath, ParentId
            FROM Categories
            WHERE IsDeleted = 0 AND ParentId IS NOT NULL AND ParentId != 0";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);
                var subcategories = await connection.QueryAsync<SubCategoryDTO>(sql, cancellationToken);
                return subcategories.AsList();
            }
        }
        #endregion
    }
}