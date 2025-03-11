using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    [Authorize]
    public class PostRequestModel(IPostRequestAppService postRequestAppService) : PageModel
    {
        [BindProperty]
        public GetDataForCreateRequestDto NewRequest { get; set; }
        [BindProperty]
        public List<ServicePackageDTO> Packages { get; set; }
        [BindProperty]
        public UserBaseDTO LogedInUser { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            Packages = await postRequestAppService.GetAllPackages(cancellationToken);
            var userid =int.Parse(User.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value);
            LogedInUser = await postRequestAppService.GetLogedInUser(userid, cancellationToken);
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var Result = await postRequestAppService.PostRequest(NewRequest, cancellationToken);
            if(!Result)
            {
                return Page();
            }
            else
            {
                return LocalRedirect("/Customer/CustomerProfile");
            }
        }
    }
}
