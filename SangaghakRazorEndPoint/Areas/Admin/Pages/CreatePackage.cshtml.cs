using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Pages
{
    public class CreatePackageModel(IServicePackageAppService servicePackageAppService) : PageModel
    {
        [BindProperty]
        public ServicePackageForCreateDTO Package { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var Result = await servicePackageAppService.CreateServicePackage(Package, cancellationToken);
            if (!Result)
            {
                TempData["Fail to Create Cagegory"] = "درخواست یجاد این کتگوری با شکست مواجه شد";
                return Page();
            }
            return RedirectToPage("SeeAllPackages");
        }
    }
}
