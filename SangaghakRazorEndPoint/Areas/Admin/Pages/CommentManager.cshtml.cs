using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Pages
{
    [Authorize(Roles = ("Admin"))]
    public class CommentManagerModel(ICommentAppService commentAppService) : PageModel
    {
        [BindProperty]
        public List<CommentDTO>? Comments { get; set; }
        [BindProperty]
        public CommentStatusEnum CommentAccepted { get; set; }
        [BindProperty]
        public CommentStatusEnum CommentNotAccepted { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            CommentAccepted = CommentStatusEnum.Confirmed;
            CommentNotAccepted = CommentStatusEnum.NotConfirmed;
            Comments = await commentAppService.GetPendingCommentAsync(cancellationToken);
        }
        public async Task<IActionResult> OnGetUpdateComment(int CommentId,CommentStatusEnum Status, CancellationToken cancellationToken)
        {
            var Result = await commentAppService.UpdateCommentStatusAsync(CommentId, Status, cancellationToken);
            if (!Result)
            {
                return NotFound();
            }
            else
            {
                return RedirectToPage("Index");
            }
        }
    }
}
