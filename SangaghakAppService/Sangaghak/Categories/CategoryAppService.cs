using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Categories
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        public CategoryAppService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<bool> CreateCategory(Category Category, CancellationToken cancellationToken)
        {
            return await _categoryService.CreateCategory(Category, cancellationToken);
        }

        public async Task<bool> CreateSubCategory(Category SubCategory, CancellationToken cancellationToken)
        {
            return await _categoryService.CreateSubCategory(SubCategory, cancellationToken);
        }

        public async Task<bool> DeleteCategory(int CategoryId, CancellationToken cancellationToken)
        {
            return  await _categoryService.DeleteCategory(CategoryId, cancellationToken);
        }

        public async Task<bool> DeleteSubCategory(int SubCategoryId, CancellationToken cancellationToken)
        {
            return await _categoryService.DeleteSubCategory(SubCategoryId, cancellationToken);
        }

        public async Task<List<Category>> FindByTitle(string title, CancellationToken cancellationToken)
        {
            return await _categoryService.FindByTitle(title, cancellationToken);
        }

        public async Task<List<Category>> GetAllCategories(CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllCategories(cancellationToken);
        }

        public async Task<List<Category>> GetAllSubCategories(CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllSubCategories(cancellationToken);
        }

        public async Task<Category> GetById(int CategoryId, CancellationToken cancellationToken)
        {
            return await _categoryService.GetById(CategoryId, cancellationToken);
        }

        public async Task<Category> GetByTitle(string title, CancellationToken cancellationToken)
        {
            return await _categoryService.GetByTitle(title, cancellationToken);
        }

        public async Task<List<Category>> GetSubCategoriesByParentId(int ParentCategoryId, CancellationToken cancellationToken)
        {
            return await _categoryService.GetSubCategoriesByParentId(ParentCategoryId, cancellationToken);
        }

        public async Task<bool> UpdateCategory(Category category, string PriorTitle, CancellationToken cancellationToken)
        {
            return await _categoryService.UpdateCategory(category, PriorTitle,cancellationToken);
        }
    }
}
