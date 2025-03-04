using System.Runtime.CompilerServices;
using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Pages
{
    public class SeeAllCommentsModel(ICommentAppService commentAppService) : PageModel
    {
        [BindProperty]
        public List<CommentDTO> Comments { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            Comments = await commentAppService.GetAllCommentsAsync(cancellationToken);
        }
    }
}
