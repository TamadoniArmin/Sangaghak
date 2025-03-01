using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Requests
{
    public class SeeRequestDetailsModel(IRequestAppService requestAppService) : PageModel
    {
        public RequestDTO Request { get; set; }
        public void OnGet(int RequestId)
        {

        }
    }
}
