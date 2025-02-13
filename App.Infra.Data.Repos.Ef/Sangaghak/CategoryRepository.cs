using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Categories;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CreateCategory(Category Category)
        {
            var WantedCategory= await _appDbContext.Categories.FirstOrDefaultAsync(x=>x.Title== Category.Title);
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

        public async Task<bool> DeleteCategory(int CategoryId)
        {
            var Category=await _appDbContext.Categories.FirstOrDefaultAsync(c=>c.Id==CategoryId);
            if(Category!=null)
            {
                _appDbContext.Categories.Remove(Category);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSubCategory(int SubCategoryId)
        {
            var Category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == SubCategoryId);
            if (Category != null)
            {
                _appDbContext.Categories.Remove(Category);
                return true;
            }
            return false;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _appDbContext.Categories.Where(x=>x.ParentId == 0 && x.ParentCategory==null).ToListAsync();
        }

        public async Task<List<Category>> GetAllSubCategories()
        {
            return await _appDbContext.Categories.Where(x => x.ParentId != 0 && x.ParentCategory != null).ToListAsync();
        }

        public async Task<Category> GetById(int CategoryId)
        {
            return await _appDbContext.Categories.FirstOrDefaultAsync(x=>x.Id== CategoryId);
        }
        public async Task<List<Category>> FindByTitle(string title)
        {
            return await _appDbContext.Categories.Where(x=>x.Title.Contains(title)).ToListAsync();
        }

        public async Task<Category> GetByTitle(string title)
        {
            return await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<List<Category>> GetSubCategoriesByParentId(int ParentCategoryId)
        {
            return await _appDbContext.Categories.Where(x=>x.ParentId == ParentCategoryId).ToListAsync();
        }

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
    }
}
