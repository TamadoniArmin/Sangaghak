using Divarcheh.Domain.Core.Contracts.AppService;
using Divarcheh.Domain.Core.Dto.User;
using Divarcheh.Domain.Core.Entities.BaseEntities;
using Divarcheh.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Divarcheh.Endpoints.RazorPages.Areas.Admin.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IBaseDataAppService _baseDataAppService;
        private readonly IUserAppService _userAppService;

        public CreateModel(IBaseDataAppService baseDataAppService, IUserAppService userAppService)
        {
            _baseDataAppService = baseDataAppService;
            _userAppService = userAppService;
        }

        [BindProperty]
        public UserDto User { get; set; }

        [BindProperty]
        public List<City> Cities { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Cities = await _baseDataAppService.GetCities(cancellationToken);
        }


        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
           await _userAppService.Register(User, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}
