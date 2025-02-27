using Divarcheh.Domain.Core.Contracts.AppService;
using Divarcheh.Domain.Core.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Divarcheh.Endpoints.RazorPages.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUserAppService _userAppService;

        public IndexModel(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [BindProperty]
        public List<UserSummaryDto> users { get; set; }
   
        public void OnGet()
        
        {
            var data = User;

            users = _userAppService.GetAll();
        }


        [HttpGet]
        public void OnGetDelete(int id)
        {

        }
    }
}
