using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Categories;

namespace SangaghakRazorEndPoint.Areas.Admin
{
    public class SeeAllCategoriesModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public List<CategoryDTO> Parents { get; set; }
        [BindProperty]
        public List<SubCategoryDTO> Childs { get; set; }
        [BindProperty]
        public int ChildCategoryId { get; set; }
        [BindProperty]
        public int ParentId { get; set; }

        public async void OnGet(int parentId, int childCategoryId,CancellationToken  cancellationToken)
        {
            Parents = await categoryAppService.GetAllParentsCategory(cancellationToken);
            if (parentId > 0)
            {
                Childs = await categoryAppService.GetSubCategoriesByParentId(parentId,cancellationToken);
            }
            else
            {
                var firstParentId = Parents.First().Id;
                Childs = await categoryAppService.GetSubCategoriesByParentId(firstParentId,cancellationToken);

            }
            ParentId = parentId;
            ChildCategoryId = childCategoryId;
        }
    }
}
