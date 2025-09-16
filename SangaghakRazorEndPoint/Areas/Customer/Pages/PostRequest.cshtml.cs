using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SangaghakAppService.Sangaghak.Pages;
using SangaghakAppService.Sangaghak.Users;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    [Authorize]
    public class PostRequestModel(IPostRequestAppService postRequestAppService,
        IUserBaseAppService userBaseAppService) : PageModel
    {
        [BindProperty]
        public GetDataForCreateRequestDto NewRequest { get; set; }
        [BindProperty]
        public int CustomerId { get; set; }
        [BindProperty]
        public List<ServicePackageDTO> Packages { get; set; }
        [BindProperty]
        public UserBaseDTO LogedInUser { get; set; }
        [BindProperty]
        public string ServicePackagesOptionsHtml { get; set; }
        [BindProperty]
        public string HiddenInputsHtml { get; set; } // پراپرتی جدید برای تگ‌های مخفی

        private bool NoCumtumerIdFound = false;

        public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
        {
            try
            {
                // دریافت پکیج‌ها
                Packages = await postRequestAppService.GetAllPackages(cancellationToken);
                Console.WriteLine($"Packages Count: {(Packages != null ? Packages.Count : "null")}");

                // تولید HTML برای گزینه‌های ServicePackage و تگ‌های مخفی
                (ServicePackagesOptionsHtml, HiddenInputsHtml) = GenerateServicePackagesOptionsHtml(Packages);

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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if (NoCumtumerIdFound)
            {
                return NotFound();
            }

            // تنظیم WantedPrice بر اساس ServicePackageId
            Packages = await postRequestAppService.GetAllPackages(cancellationToken);
            var selectedPackage = Packages?.FirstOrDefault(p => p.Id == NewRequest.ServicePackageId);
            if (selectedPackage != null)
            {
                NewRequest.WantedPrice = selectedPackage.MinPrice;
            }

            var Result = await postRequestAppService.PostRequest(NewRequest, cancellationToken);
            if (!Result)
            {
                // بازتولید HTML گزینه‌ها و تگ‌های مخفی در صورت خطا
                (ServicePackagesOptionsHtml, HiddenInputsHtml) = GenerateServicePackagesOptionsHtml(Packages);
                return Page();
            }
            else
            {
                return RedirectToPage("Index");
            }
        }

        private (string OptionsHtml, string HiddenInputsHtml) GenerateServicePackagesOptionsHtml(List<ServicePackageDTO> packages)
        {
            var optionsBuilder = new StringBuilder();
            var hiddenInputsBuilder = new StringBuilder();

            optionsBuilder.AppendLine("<option value=\"0\" data-display=\"UI/UX Designer\">انتخاب کنید....</option>");

            if (packages?.Any() == true)
            {
                foreach (var package in packages)
                {
                    optionsBuilder.AppendLine(
                        $@"<option value=""{package.Id}"">{HttpUtility.HtmlEncode(package.Title)} / ({HttpUtility.HtmlEncode(package.SubCategoryTitle)})</option>");
                    hiddenInputsBuilder.AppendLine(
                        $@"<input type=""hidden"" name=""WantedPrice{package.Id}"" value=""{package.MinPrice}"">");
                }
            }

            return (optionsBuilder.ToString(), hiddenInputsBuilder.ToString());
        }
    }
}
