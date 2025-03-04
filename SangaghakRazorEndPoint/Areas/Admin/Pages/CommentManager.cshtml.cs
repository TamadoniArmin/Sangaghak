using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Admin.Pages
{
    public class CommentManagerModel(ICommentAppService commentAppService) : PageModel
    {
        [BindProperty]
        public List<CommentDTO> Comments { get; set; }
        [BindProperty]
        public int CommentId { get; set; }
        [BindProperty]
        public CommentStatusEnum Status { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            Comments = await commentAppService.GetPendingCommentAsync(cancellationToken);
        }
        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var Result = await commentAppService.UpdateCommentStatusAsync(CommentId, Status, cancellationToken);
            if (!Result)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}
