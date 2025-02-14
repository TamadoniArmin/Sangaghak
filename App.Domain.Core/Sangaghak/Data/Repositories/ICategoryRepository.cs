

using App.Domain.Core.Sangaghak.Entities.Categories;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface ICategoryRepository
    {
        #region Create
        public Task<bool> CreateCategory(Category Category);
        public Task<bool> CreateSubCategory(Category SubCategory);
        #endregion
        #region Read
        public Task<List<Category>> GetAllCategories();
        public Task<Category> GetById(int CategoryId);
        public Task<List<Category>> FindByTitle(string title);//برای سرچ کردن کتگوری
        public Task<Category> GetByTitle(string title);
        public Task<List<Category>> GetAllSubCategories();
        public Task<List<Category>> GetSubCategoriesByParentId(int ParentCategoryId);
        #endregion
        #region Update
        public Task<bool> UpdateCategory(Category category, string PriorTitle);
        #endregion
        #region Delete
        public Task<bool> DeleteCategory(int CategoryId);
        public Task<bool> DeleteSubCategory(int SubCategoryId);
        #endregion
    }
}
