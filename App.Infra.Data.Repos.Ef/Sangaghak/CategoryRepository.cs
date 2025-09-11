using System;
using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Categories;
using Connection.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{

    public class CategoryRepository : ICategoryRepository
    {
        #region Dependency Injection
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<CategoryRepository> _logger;
        public CategoryRepository(AppDbContext appDbContext, ILogger<CategoryRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }
        #endregion
        #region Create
        public async Task<bool> CreateCategory(CategoryForCreateDto Model, CancellationToken cancellationToken)
        {
            try
            {
                var Category = new Category()
                {
                    Title = Model.Title,
                    Description = Model.Description,
                    ImagePath = Model.ImagePath,
                };
                await _appDbContext.Categories.AddAsync(Category, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception("Exception");
            }
        }

        public async Task<bool> CreateSubCategory(SubCategoryFroCreateDto Model, CancellationToken cancellationToken)
        {
            try
            {
                var SubCategory = new Category()
                {
                    Title = Model.Title,
                    Description = Model.Description,
                    ImagePath = Model.ImagePath,
                    ParentId = Model.ParentId
                };
                await _appDbContext.Categories.AddAsync(SubCategory, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception("Exception");
            }
        }
        #endregion
        #region Read
        public async Task<List<GetSubcategoryForHomePageDto>> FindByTitle(string title, CancellationToken cancellationToken)
        {
            var subcategories = await _appDbContext
            .Categories
            .Where(x => x.Title.Contains(title) && x.IsDeleted == false)
            .Include(x => x.Experts)//<<--پرسیده شود
            .Select(x => new GetSubcategoryForHomePageDto
            {
                CategoryId = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImagePath = x.ImagePath,
                ExpertsCount = x.Experts.Count
            }).ToListAsync(cancellationToken);
            return subcategories;
        }

        public async Task<List<CategoryDTO>> GetAllCategories(CancellationToken cancellationToken)
        {
            var categories = await _appDbContext
            .Categories
            .Where(x => x.IsDeleted == false)
            .Include(x => x.Subcategories)
            .Select(x => new CategoryDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImagePath = x.ImagePath,
                SubCategoryCount = x.Subcategories.Count,
            }).ToListAsync(cancellationToken);
            return categories;
        }

        public async Task<List<SubCategoryDTO>> GetAllSubCategories(CancellationToken cancellationToken)
        {
            _logger.Log(logLevel: LogLevel.Information, "ادمین تلاش کرد زیر کتگوری ها را بخواند");
            var subcategories = await _appDbContext
            .Categories
            .Where(x => x.IsDeleted == false && x.ParentId != 0 && x.ParentId != null)
            .Select(x => new SubCategoryDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImagePath = x.ImagePath,
                ParentId = x.ParentId ?? 0
            }).ToListAsync(cancellationToken);
            return subcategories;
        }
        public async Task<GetSubcategoryForHomePageDto> GetByTitle(string title, CancellationToken cancellationToken)
        {
            var FindCategory = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Title == title && x.IsDeleted == false, cancellationToken);
            if (FindCategory != null)
            {
                var Subcategory = new GetSubcategoryForHomePageDto()
                {
                    CategoryId = FindCategory.Id,
                    Title = FindCategory.Title,
                    Description = FindCategory.Description,
                    ImagePath = FindCategory.ImagePath,
                    ExpertsCount = FindCategory.Experts.Count

                };
                return Subcategory;
            }
            return null;//اینجا لاگ بزن
        }

        public async Task<List<SubCategoryDTO>> GetSubCategoriesByParentId(int ParentCategoryId, CancellationToken cancellationToken)
        {
            var subcategories = await _appDbContext
            .Categories
            .Where(x => x.ParentId == ParentCategoryId && x.IsDeleted == false)
            .Include(x => x.Experts)//<<--پرسیده شود
            .Select(x => new SubCategoryDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImagePath = x.ImagePath,
                ParentId = x.ParentId ?? 0
            }).ToListAsync(cancellationToken);
            return subcategories;
        }
        public async Task<CategoryDTO> GetCategoryByIdAysnc(int Id, CancellationToken cancellationToken)
        {
            var Category = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
            if (Category is null) return null;
            else
            {
                CategoryDTO categoryDTO = new CategoryDTO()
                {
                    Id = Category.Id,
                    Title = Category.Title,
                    Description = Category.Description,
                    ImagePath = Category.ImagePath ?? string.Empty,
                    SubCategoryCount = 0
                };
                return categoryDTO;
            }
        }
        public async Task<List<CategoryDTO>> GetAllParentsCategory(CancellationToken cancellationToken)
        {
            _logger.Log(logLevel: LogLevel.Information, "ادمین تلاش کرد کتگوری ها را بخواند");
            return await _appDbContext
                .Categories
                .Where(x => (x.ParentId == null || x.ParentId == 0) && x.IsDeleted == false)
                .Select(x => new CategoryDTO()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ImagePath = x.ImagePath ?? string.Empty,
                    SubCategoryCount = x.Subcategories.Count()
                }).ToListAsync(cancellationToken);
        }
        public async Task<string> GetSubCategoryNameByIdAysnc(int Id, CancellationToken cancellationToken)
        {
            var Category = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
            if (Category is null) return string.Empty;
            else return Category.Title;
        }
        public async Task<SubCategoryDTO> GetSubCategoryByIdAysnc(int Id, CancellationToken cancellationToken)
        {
            var Category = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
            if (Category is null) return null;
            else
            {
                SubCategoryDTO categoryDTO = new SubCategoryDTO()
                {
                    Id = Category.Id,
                    Title = Category.Title,
                    Description = Category.Description,
                    ImagePath = Category.ImagePath ?? string.Empty,
                    ParentId = Category.ParentId ?? 0
                };
                return categoryDTO;
            }
        }
        #endregion
        #region Update
        public async Task<bool> UpdateSubCategory(SubCategoryDTO Model, int SubCategoryId, CancellationToken cancellationToken)
        {
            _logger.Log(logLevel: LogLevel.Information, "کاربر تلاش کرد زیرکتگوریی را آپدیت کند");
            var Category = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == SubCategoryId, cancellationToken);
            if (Category == null) return false;
            Category.Title = Model.Title;
            Category.Description = Model.Description;
            if (Model.ImagePath is not null)
                Category.ImagePath = Model.ImagePath;
            Category.ParentId = Model.ParentId;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
        public async Task<bool> UpdateCategory(CategoryDTO Model, int CategoryId, CancellationToken cancellationToken)
        {
            _logger.Log(logLevel: LogLevel.Information, "کاربر تلاش کرد کتگوریی را آپدیت کند");
            var Category = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == CategoryId, cancellationToken);
            if (Category == null) return false;
            Category.Title = Model.Title;
            Category.Description = Model.Description;
            if (Model.ImagePath is not null)
                Category.ImagePath = Model.ImagePath;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteCategory(int CategoryId, CancellationToken cancellationToken)
        {
            var Category = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == CategoryId && x.IsDeleted == false, cancellationToken);
            if (Category == null) return false;
            Category.IsDeleted = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
        #endregion
    }
}
