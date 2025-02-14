using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Categories;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{

    public class CategoryRepository : ICategoryRepository
    {
        #region Dependency Injection
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion
        #region Create
        public async Task<bool> CreateCategory(Category Category)
        {
            var WantedCategory = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Title == Category.Title);
            if (WantedCategory == null)
            {
                await _appDbContext.Categories.AddAsync(Category);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CreateSubCategory(Category SubCategory)
        {
            var WantedSubCategory = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Title == SubCategory.Title);
            if (WantedSubCategory == null)
            {
                await _appDbContext.Categories.AddAsync(SubCategory);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
        #region Read
        public async Task<List<Category>> GetAllCategories()
        {
            return await _appDbContext.Categories.Where(x => x.ParentId == 0 && x.ParentCategory == null && x.IsDeleted==false).ToListAsync();
        }

        public async Task<List<Category>> GetAllSubCategories()
        {
            return await _appDbContext.Categories.Where(x => x.ParentId != 0 && x.ParentCategory != null && x.IsDeleted == false).ToListAsync();
        }

        public async Task<Category> GetById(int CategoryId)
        {
            return await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == CategoryId && x.IsDeleted==false);
        }
        public async Task<List<Category>> FindByTitle(string title)
        {
            return await _appDbContext.Categories.Where(x => x.Title.Contains(title) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<Category> GetByTitle(string title)
        {
            return await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Title == title && x.IsDeleted==false);
        }

        public async Task<List<Category>> GetSubCategoriesByParentId(int ParentCategoryId)
        {
            return await _appDbContext.Categories.Where(x => x.ParentId == ParentCategoryId && x.IsDeleted == false).ToListAsync();
        }
        #endregion
        #region Update
        public async Task<bool> UpdateCategory(Category category, string PriorTitle)
        {
            var WantedCategory = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Title == PriorTitle);
            if (WantedCategory != null)
            {
                WantedCategory.Title = category.Title;
                //WantedCategory.Image = category.Image;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteCategory(int CategoryId)
        {
            var Category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == CategoryId && c.IsDeleted==false);
            if (Category != null)
            {
                Category.IsDeleted = true;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSubCategory(int SubCategoryId)
        {
            var Category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == SubCategoryId && c.IsDeleted == false);
            if (Category != null)
            {
                Category.IsDeleted = true;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
    }
}
