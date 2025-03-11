using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace SangaghakRazorEndPoint.Areas.Admin.Pages.Edits
{
    public class EditPackageModel(IServicePackageAppService servicePackageAppService) : PageModel
    {
        [BindProperty]
        public ServicePackageDTO WantedPackage { get; set; }
        [BindProperty]
        public ServicePackageForCreateDTO UpdatedPackage { get; set; }
        public async Task OnGet(int PackageId,CancellationToken cancellationToken)
        {
            WantedPackage = await servicePackageAppService.GetPackageById(PackageId, cancellationToken);
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var Result = await servicePackageAppService.UpdateServicePackage(UpdatedPackage, UpdatedPackage.Id,cancellationToken);
            if (!Result)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("SeeAllPackages");
            }

        }
    }
}
