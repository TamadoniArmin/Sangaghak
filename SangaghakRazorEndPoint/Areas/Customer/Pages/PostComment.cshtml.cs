using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SangaghakRazorEndPoint.Areas.Customer.Pages
{
    [Authorize(Roles = ("Customer"))]
    public class PostCommentModel(ICommentAppService commentAppService) : PageModel
    {
        [BindProperty]
        public CommentForCreateDTO NewComment { get; set; }
        public async Task<IActionResult> OnGet(int CustomerId, int ExpertId, int RequestId,CancellationToken cancellationToken)
        {
            TempData["CustomerId"] = CustomerId;
            TempData["ExpertId"] = ExpertId;
            TempData["RequestId"] = RequestId;
            return Page();
        }

        public async Task<IActionResult> OnPostCreateComment(CancellationToken cancellationToken)
        {
            NewComment.CustomerId = Convert.ToInt32(TempData["CustomerId"]);
            NewComment.ExpertId = Convert.ToInt32(TempData["ExpertId"]);
            NewComment.RequestId = Convert.ToInt32(TempData["RequestId"]);
            var Result = await commentAppService.CreateCommentAsync(NewComment, cancellationToken);
            if (Result)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage("PostComment", new { CustomerId= TempData["CustomerId"] , ExpertId= TempData["ExpertId"], RequestId= TempData["RequestId"] });
            }
        }
    }
}
