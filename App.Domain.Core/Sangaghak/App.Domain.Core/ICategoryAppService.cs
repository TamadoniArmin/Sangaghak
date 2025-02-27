using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Categories;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface ICategoryAppService
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
        #endregion
        #region Update
        public Task<bool> UpdateCategory(SubCategoryDTO Model, string PriorTitle, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteCategory(int CategoryId, CancellationToken cancellationToken);
        #endregion
    }
}
