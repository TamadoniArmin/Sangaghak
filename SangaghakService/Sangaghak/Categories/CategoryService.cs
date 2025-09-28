using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Service;
using App.Infra.Data.Repos.Ef.Sangaghak;

namespace SangaghakService.Sangaghak.Categories
{
    public class CategoryService : ICategoryService
    {
        #region Dependency Injection
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDapperRepository _dapperRepository;
        public CategoryService(ICategoryRepository categoryRepository,
            IDapperRepository dapperRepository)
        {
            _categoryRepository = categoryRepository;
            _dapperRepository = dapperRepository;
        }
        #endregion
        #region Create
        public async Task<bool> CreateCategory(CategoryForCreateDto Model, CancellationToken cancellationToken)
        {
            return await _categoryRepository.CreateCategory(Model, cancellationToken);
        }

        public async Task<bool> CreateSubCategory(SubCategoryFroCreateDto Model, CancellationToken cancellationToken)
        {
            return await _categoryRepository.CreateSubCategory(Model, cancellationToken);
        }
        #endregion
        #region Read
        public async Task<List<GetSubcategoryForHomePageDto>> FindByTitle(string title, CancellationToken cancellationToken)
        {
            return await _categoryRepository.FindByTitle(title, cancellationToken);
        }

        public async Task<List<CategoryDTO>> GetAllCategories(CancellationToken cancellationToken)
        {
            return await _dapperRepository.GetAllCategories(cancellationToken);
        }

        public async Task<List<CategoryDTO>> GetAllParentsCategory(CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAllParentsCategory(cancellationToken);
        }

        public async Task<List<SubCategoryDTO>> GetAllSubCategories(CancellationToken cancellationToken)
        {
            return await _dapperRepository.GetAllSubCategories(cancellationToken);
        }

        public async Task<GetSubcategoryForHomePageDto> GetByTitle(string title, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetByTitle(title, cancellationToken);
        }

        public async Task<CategotyOrSubCategoryBasicInfo?> GetCategoryBasicInfo(int CategoryId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategoryBasicInfo(CategoryId, cancellationToken);
        }

        public async Task<CategoryDTO> GetCategoryByIdAysnc(int Id, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategoryByIdAysnc(Id, cancellationToken);
        }

        public async Task<List<int>> GetCategoryIdByExpertId(int expertId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategoryIdByExpertId(expertId, cancellationToken);
        }

        public async Task<List<GetSubCategoryNameForExpertsDTO>> GetCategoryNamesByExpertId(int expertId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategoryNamesByExpertId(expertId, cancellationToken);
        }

        public async Task<List<SubCategoryDTO>> GetSubCategoriesByParentId(int ParentCategoryId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetSubCategoriesByParentId(ParentCategoryId, cancellationToken);
        }

        public async Task<List<Category>> GetSubCategoriesForExpertSkillsAsync(List<int> SubCategoriesId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetSubCategoriesForExpertSkillsAsync(SubCategoriesId, cancellationToken);
        }

        public async Task<SubCategoryDTO> GetSubCategoryByIdAysnc(int Id, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetSubCategoryByIdAysnc(Id, cancellationToken);
        }

        public async Task<string> GetSubCategoryNameByIdAysnc(int Id, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetSubCategoryNameByIdAysnc(Id, cancellationToken);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateCategory(CategoryDTO Model, int CategoryId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.UpdateCategory(Model, CategoryId, cancellationToken);
        }

        public async Task<bool> UpdateSubCategory(SubCategoryDTO Model, int SubCategoryId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.UpdateSubCategory(Model, SubCategoryId, cancellationToken);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteCategory(int CategoryId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.DeleteCategory(CategoryId, cancellationToken);
        }

        #endregion
    }
}
