
using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Pages;
using SangaghakAppService.Sangaghak.ServicePackages;
using SangaghakAppService.Sangaghak.Users;
using System.Threading.Tasks;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    [Authorize]
    public class PostRequestWithPackageIdModel(IServicePackageAppService servicePackageAppService,
        IPostRequestAppService postRequestAppService,
        IUserBaseAppService userBaseAppService) : PageModel
    {
        [BindProperty]
        public ServicePackageBasicInfoDTO WantedPackage { get; set; }
        [BindProperty]
        public GetDataForCreateRequestDto NewRequest { get; set; }
        [BindProperty]
        public int CustomerId { get; set; }
        [BindProperty]
        public UserBaseDTO LogedInUser { get; set; }
        private bool NoCumtumerIdFound = false;
        public async Task<IActionResult> OnGet(int PackageId, CancellationToken cancellationToken)
        {
            try
            {
                if (PackageId == 0)
                {
                    return NotFound();
                }
                var Package = await servicePackageAppService.GetPackageBasicInfo(PackageId, cancellationToken);
                if (Package == null)
                {
                    return NotFound();
                }
                else
                {
                    WantedPackage = Package;
                    TempData["PackageId"] = WantedPackage.Id;
                    // دریافت اطلاعات کاربر
                    var userid = int.Parse(User.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value);
                    var WantedCustomerId = await userBaseAppService.GetCustomerIdByUserId(userid, cancellationToken);
                    if (WantedCustomerId <= 0)
                    {
                        NoCumtumerIdFound = true;
                        return NotFound();
                    }
                    else
                    {
                        CustomerId = WantedCustomerId;
                    }

                    LogedInUser = await postRequestAppService.GetLogedInUser(userid, cancellationToken);

                    return Page();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500);
            }
            
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            //if (!ModelState.IsValid)
            //{
            //    var PackageId = Convert.ToInt32(TempData["PackageId"]);
            //    // در صورت خطای اعتبارسنجی، WantedPackage را دوباره لود کنید
            //    var Package = await servicePackageAppService.GetPackageBasicInfo(PackageId, cancellationToken);
            //    if (Package == null)
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        WantedPackage = Package;
            //        // دریافت اطلاعات کاربر
            //        var userid = int.Parse(User.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value);
            //        var WantedCustomerId = await userBaseAppService.GetCustomerIdByUserId(userid, cancellationToken);
            //        if (WantedCustomerId <= 0)
            //        {
            //            NoCumtumerIdFound = true;
            //            return NotFound();
            //        }
            //        else
            //        {
            //            CustomerId = WantedCustomerId;
            //        }

            //        LogedInUser = await postRequestAppService.GetLogedInUser(userid, cancellationToken);

            //        return Page();
            //    }
            //}
            if (NoCumtumerIdFound)
            {
                return NotFound();
            }
            var Result = await postRequestAppService.PostRequest(NewRequest, cancellationToken);
            if (!Result)
            {
                return RedirectToPage("PostRequestWithPackageId", new { PackageId = TempData["PackageId"] });
            }
            else
            {
                return RedirectToPage("Index");
            }
        }
    }
}
