﻿using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
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

        public async Task<bool> CreateCategory(CategoryForCreateDto Model, CancellationToken cancellationToken)
        {
            return await _categoryService.CreateCategory(Model, cancellationToken);
        }

        public async Task<bool> CreateSubCategory(SubCategoryFroCreateDto Model, CancellationToken cancellationToken)
        {
            return await _categoryService.CreateSubCategory(Model, cancellationToken);
        }

        public async Task<bool> DeleteCategory(int CategoryId, CancellationToken cancellationToken)
        {
            return await _categoryService.DeleteCategory(CategoryId, cancellationToken);
        }

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
            return await _categoryService.GetAllSubCategories(cancellationToken);
        }

        public async Task<GetSubcategoryForHomePageDto> GetByTitle(string title, CancellationToken cancellationToken)
        {
            return await _categoryService.GetByTitle(title, cancellationToken);
        }

        public async Task<CategoryDTO> GetCategoryByIdAysnc(int Id, CancellationToken cancellationToken)
        {
            return await _categoryService.GetCategoryByIdAysnc(Id, cancellationToken);
        }

        public async Task<List<SubCategoryDTO>> GetSubCategoriesByParentId(int ParentCategoryId, CancellationToken cancellationToken)
        {
            return await _categoryService.GetSubCategoriesByParentId(ParentCategoryId, cancellationToken);
        }

        public async Task<bool> UpdateCategory(SubCategoryDTO Model, string PriorTitle, CancellationToken cancellationToken)
        {
            return await _categoryService.UpdateCategory(Model, PriorTitle, cancellationToken);
        }
    }
}
