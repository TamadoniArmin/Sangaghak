using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace SangaghakRazorEndPoint.Areas.Admin.Pages
{
    public class SeeAllPackagesModel(IServicePackageAppService servicePackageAppService) : PageModel
    {
        public List<ServicePackageDTO> AllPackages { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            AllPackages = await servicePackageAppService.GetAllAsync(cancellationToken);
        }
        public async Task<IActionResult> OnGetDelete(int PackageId, CancellationToken cancellationToken)
        {
            var Result = await servicePackageAppService.DeleteServicePackage(PackageId, cancellationToken);
            if (Result)
            {
                return RedirectToPage("SeeAllPackages");
            }
            return RedirectToPage("SeeAllPackages");
        }
    }
}
