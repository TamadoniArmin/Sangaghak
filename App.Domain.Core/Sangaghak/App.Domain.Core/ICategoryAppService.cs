using App.Domain.Core.Sangaghak.Entities.Categories;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface ICategoryAppService
    {
        #region Create
        public Task<bool> CreateCategory(Category Category, CancellationToken cancellationToken);
        public Task<bool> CreateSubCategory(Category SubCategory, CancellationToken cancellationToken);
        #endregion
        #region Read
        public Task<List<Category>> GetAllCategories(CancellationToken cancellationToken);
        public Task<Category> GetById(int CategoryId, CancellationToken cancellationToken);
        public Task<List<Category>> FindByTitle(string title, CancellationToken cancellationToken);//برای سرچ کردن کتگوری
        public Task<Category> GetByTitle(string title, CancellationToken cancellationToken);
        public Task<List<Category>> GetAllSubCategories(CancellationToken cancellationToken);
        public Task<List<Category>> GetSubCategoriesByParentId(int ParentCategoryId, CancellationToken cancellationToken);
        #endregion
        #region Update
        public Task<bool> UpdateCategory(Category category, string PriorTitle, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteCategory(int CategoryId, CancellationToken cancellationToken);
        public Task<bool> DeleteSubCategory(int SubCategoryId, CancellationToken cancellationToken);
        #endregion
    }
}
