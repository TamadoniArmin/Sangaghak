using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Categories;

namespace App.Domain.Core.Sangaghak.Service
{
    public interface ICategoryService
    {
        #region Create
        public Task<bool> CreateCategory(CategoryForCreateDto Model, CancellationToken cancellationToken);
        public Task<bool> CreateSubCategory(SubCategoryFroCreateDto Model, CancellationToken cancellationToken);
        #endregion
        #region Read
        public Task<List<CategoryDTO>> GetAllCategories(CancellationToken cancellationToken);
        public Task<List<GetSubcategoryForHomePageDto>> FindByTitle(string title, CancellationToken cancellationToken);//برای سرچ کردن کتگوری
        public Task<GetSubcategoryForHomePageDto> GetByTitle(string title, CancellationToken cancellationToken);
        public Task<List<CategoryDTO>> GetAllParentsCategory(CancellationToken cancellationToken);
        public Task<List<SubCategoryDTO>> GetAllSubCategories(CancellationToken cancellationToken);
        public Task<List<SubCategoryDTO>> GetSubCategoriesByParentId(int ParentCategoryId, CancellationToken cancellationToken);
        public Task<CategoryDTO> GetCategoryByIdAysnc(int Id, CancellationToken cancellationToken);
        public Task<SubCategoryDTO> GetSubCategoryByIdAysnc(int Id, CancellationToken cancellationToken);
        public Task<string> GetSubCategoryNameByIdAysnc(int Id, CancellationToken cancellationToken);
        #endregion
        #region Update
        public Task<bool> UpdateSubCategory(SubCategoryDTO Model, int SubCategoryId, CancellationToken cancellationToken);
        public Task<bool> UpdateCategory(CategoryDTO Model, int CategoryId, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteCategory(int CategoryId, CancellationToken cancellationToken);
        #endregion
    }
}

