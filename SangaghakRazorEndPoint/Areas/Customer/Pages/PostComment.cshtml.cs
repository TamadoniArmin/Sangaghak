using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    [Authorize(Roles = ("Customer"))]
    public class PostCommentModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
