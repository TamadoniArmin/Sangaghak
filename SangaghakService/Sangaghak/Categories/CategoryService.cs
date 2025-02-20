using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> CreateCategory(Category Category, CancellationToken cancellationToken)
        {
            return await _categoryRepository.CreateCategory(Category, cancellationToken);
        }

        public async Task<bool> CreateSubCategory(Category SubCategory, CancellationToken cancellationToken)
        {
            return await _categoryRepository.CreateSubCategory(SubCategory, cancellationToken);
        }

        public async Task<bool> DeleteCategory(int CategoryId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.DeleteCategory(CategoryId, cancellationToken);
        }

        public async Task<bool> DeleteSubCategory(int SubCategoryId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.DeleteSubCategory(SubCategoryId, cancellationToken);
        }

        public async Task<List<Category>> FindByTitle(string title, CancellationToken cancellationToken)
        {
            return await _categoryRepository.FindByTitle(title, cancellationToken);
        }

        public async Task<List<Category>> GetAllCategories(CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAllCategories(cancellationToken);
        }

        public async Task<List<Category>> GetAllSubCategories(CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAllSubCategories(cancellationToken);
        }

        public async Task<Category> GetById(int CategoryId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetById(CategoryId, cancellationToken);
        }

        public async Task<Category> GetByTitle(string title, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetByTitle(title, cancellationToken);
        }

        public async Task<List<Category>> GetSubCategoriesByParentId(int ParentCategoryId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetSubCategoriesByParentId(ParentCategoryId, cancellationToken);
        }

        public async Task<bool> UpdateCategory(Category category, string PriorTitle, CancellationToken cancellationToken)
        {
            return await _categoryRepository.UpdateCategory(category, PriorTitle,cancellationToken);
        }
    }
}
