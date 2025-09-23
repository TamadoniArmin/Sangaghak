using App.Domain.Core.Sangaghak.App.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace SangaghakRazorEndPoint.Areas.Public.Pages
{
    public class LogoutModel(IUserBaseAppService userBaseAppService) : PageModel
    {

        public async Task<IActionResult> OnGetAsync()
        {
            await userBaseAppService.LogoutAsync();
            return LocalRedirect("/Public/Index");
        }
    }
}

