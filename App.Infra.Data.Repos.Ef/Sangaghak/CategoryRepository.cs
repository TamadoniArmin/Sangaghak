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
        public async Task<bool> CreateCategory(Category Category, CancellationToken cancellationToken)
        {
            var WantedCategory = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Title == Category.Title);
            if (WantedCategory == null)
            {
                await _appDbContext.Categories.AddAsync(Category ,cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<bool> CreateSubCategory(Category SubCategory, CancellationToken cancellationToken)
        {
            var WantedSubCategory = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Title == SubCategory.Title);
            if (WantedSubCategory == null)
            {
                await _appDbContext.Categories.AddAsync(SubCategory, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
        #region Read
        public async Task<List<Category>> GetAllCategories(CancellationToken cancellationToken)
        {
            return await _appDbContext.Categories.Where(x => x.ParentId == 0 && x.ParentCategory == null && x.IsDeleted==false).ToListAsync(cancellationToken);
        }

        public async Task<List<Category>> GetAllSubCategories(CancellationToken cancellationToken)
        {
            return await _appDbContext.Categories.Where(x => x.ParentId != 0 && x.ParentCategory != null && x.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task<Category> GetById(int CategoryId, CancellationToken cancellationToken)
        {
            return await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == CategoryId && x.IsDeleted==false, cancellationToken);
        }
        public async Task<List<Category>> FindByTitle(string title, CancellationToken cancellationToken)
        {
            return await _appDbContext.Categories.Where(x => x.Title.Contains(title) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<Category> GetByTitle(string title, CancellationToken cancellationToken)
        {
            return await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Title == title && x.IsDeleted==false, cancellationToken);
        }

        public async Task<List<Category>> GetSubCategoriesByParentId(int ParentCategoryId, CancellationToken cancellationToken)
        {
            return await _appDbContext.Categories.Where(x => x.ParentId == ParentCategoryId && x.IsDeleted == false).ToListAsync(cancellationToken);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateCategory(Category category, string PriorTitle, CancellationToken cancellationToken)
        {
            var WantedCategory = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Title == PriorTitle, cancellationToken);
            if (WantedCategory != null)
            {
                WantedCategory.Title = category.Title;
                //WantedCategory.Image = category.Image;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteCategory(int CategoryId, CancellationToken cancellationToken)
        {
            var Category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == CategoryId && c.IsDeleted==false, cancellationToken);
            if (Category != null)
            {
                Category.IsDeleted = true;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSubCategory(int SubCategoryId, CancellationToken cancellationToken)
        {
            var Category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == SubCategoryId && c.IsDeleted == false, cancellationToken);
            if (Category != null)
            {
                Category.IsDeleted = true;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
    }
}
