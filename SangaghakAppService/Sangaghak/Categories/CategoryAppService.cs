using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Categories
{
    public class CategoryAppService : ICategoryAppService
    {
        #region Dependency Injection
        private readonly ICategoryService _categoryService;
        private readonly IGeneralService _generalService;
        public CategoryAppService(ICategoryService categoryService, IGeneralService generalService)
        {
            _categoryService = categoryService;
            _generalService = generalService;
        }
        #endregion
        #region Create
        public async Task<bool> CreateCategory(CategoryForCreateDto Model, CancellationToken cancellationToken)
        {
            if (Model.ImageFile is not null)
            {
                Model.ImagePath = await _generalService.UploadImage(Model.ImageFile!, "Categories", cancellationToken);
            }
            return await _categoryService.CreateCategory(Model, cancellationToken);
        }

        public async Task<bool> CreateSubCategory(SubCategoryFroCreateDto Model, CancellationToken cancellationToken)
        {
            if (Model.ImageFile is not null)
            {
                Model.ImagePath = await _generalService.UploadImage(Model.ImageFile!, "SubCategories", cancellationToken);
            }
            return await _categoryService.CreateSubCategory(Model, cancellationToken);
        }


        #endregion
        #region Read
        public async Task<List<GetSubcategoryForHomePageDto>> FindByTitle(string title, CancellationToken cancellationToken)
        {
            return await _categoryService.FindByTitle(title, cancellationToken);
        }

        public async Task<List<CategoryDTO>> GetAllCategories(CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllCategories(cancellationToken);
        }

        public async Task<List<CategoryDTO>> GetAllParentsCategory(CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllParentsCategory(cancellationToken);
        }

        public async Task<List<SubCategoryDTO>> GetAllSubCategories(CancellationToken cancellationToken)
        {
            var Subcategoirs = await _categoryService.GetAllSubCategories(cancellationToken);
            foreach (var subcategory in Subcategoirs)
            {
                subcategory.ParentName = await _categoryService.GetSubCategoryNameByIdAysnc(subcategory.ParentId, cancellationToken);
            }
            return Subcategoirs;
        }

        public async Task<GetSubcategoryForHomePageDto> GetByTitle(string title, CancellationToken cancellationToken)
        {
            return await _categoryService.GetByTitle(title, cancellationToken);
        }

        public async Task<CategotyOrSubCategoryBasicInfo?> GetCategoryBasicInfo(int CategoryId, CancellationToken cancellationToken)
        {
            return await _categoryService.GetCategoryBasicInfo(CategoryId, cancellationToken);
        }

        public async Task<CategoryDTO> GetCategoryByIdAysnc(int Id, CancellationToken cancellationToken)
        {
            return await _categoryService.GetCategoryByIdAysnc(Id, cancellationToken);
        }

        public async Task<List<SubCategoryDTO>> GetSubCategoriesByParentId(int ParentCategoryId, CancellationToken cancellationToken)
        {
            return await _categoryService.GetSubCategoriesByParentId(ParentCategoryId, cancellationToken);
        }

        public async Task<SubCategoryDTO> GetSubCategoryByIdAysnc(int Id, CancellationToken cancellationToken)
        {
            return await _categoryService.GetSubCategoryByIdAysnc(Id, cancellationToken);
        }


        #endregion
        #region Update
        public async Task<bool> UpdateCategory(CategoryDTO Model, int CategoryId, CancellationToken cancellationToken)
        {
            if (Model.ImgFile is not null)
            {
                Model.ImagePath = await _generalService.UploadImage(Model.ImgFile!, "Categories", cancellationToken);
            }
            return await _categoryService.UpdateCategory(Model, CategoryId, cancellationToken);
        }

        public async Task<bool> UpdateSubCategory(SubCategoryDTO Model, int SubCategoryId, CancellationToken cancellationToken)
        {
            if (Model.ImageFile is not null)
            {
                Model.ImagePath = await _generalService.UploadImage(Model.ImageFile!, "SubCategories", cancellationToken);
            }
            return await _categoryService.UpdateSubCategory(Model, SubCategoryId, cancellationToken);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteCategory(int CategoryId, CancellationToken cancellationToken)
        {
            return await _categoryService.DeleteCategory(CategoryId, cancellationToken);
        }


        #endregion

    }
}
