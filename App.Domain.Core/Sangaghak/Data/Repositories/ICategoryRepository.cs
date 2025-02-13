

using App.Domain.Core.Sangaghak.Entities.Categories;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface ICategoryRepository
    {
        public Task<bool> CreateCategory(Category Category);
        public Task<bool> CreateSubCategory(Category SubCategory);
        public Task<List<Category>> GetAllCategories();
        public Task<Category> GetById(int CategoryId);
        public Task<List<Category>> FindByTitle(string title);//برای سرچ کردن کتگوری
        public Task<Category> GetByTitle(string title);
        public Task<List<Category>> GetAllSubCategories();
        public Task<List<Category>> GetSubCategoriesByParentId(int ParentCategoryId);
        public Task<bool> UpdateCategory(Category category, string PriorTitle);
        public Task<bool> DeleteCategory(int CategoryId);
        public Task<bool> DeleteSubCategory(int SubCategoryId);

    }
}
