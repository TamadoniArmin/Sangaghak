using Divarcheh.Domain.Core.Contracts.AppService;
using Divarcheh.Domain.Core.Dto.Advertisement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Divarcheh.Endpoints.RazorPages.Pages.Advertisement
{
    public class SelectCategoryModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public List<CategoryDto> Parents { get; set; }
        [BindProperty]
        public List<CategoryDto> Childs { get; set; }
        [BindProperty]
        public int ChildCategoryId { get; set; }
        [BindProperty]
        public int ParentId { get; set; }

        public void OnGet(int parentId, int childCategoryId)
        {
            Parents = categoryAppService.GetParentCategories();
            if (parentId > 0)
            {
                Childs = categoryAppService.GetChildCategories(parentId);
            }
            else
            {
                var firstParentId = Parents.First().Id;
                Childs = categoryAppService.GetChildCategories(firstParentId);
             
            }
            ParentId = parentId;
            ChildCategoryId = childCategoryId;
        }
    }
}
