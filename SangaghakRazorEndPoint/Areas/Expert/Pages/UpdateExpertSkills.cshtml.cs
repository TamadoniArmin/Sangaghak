using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Entities.Users;
using Connection.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SangaghakRazorEndPoint.Areas.Expert.Pages
{
    [Authorize]
    public class UpdateExpertSkillsModel(ICategoryAppService categoryAppService,
        IExpertAppService expertAppService) : PageModel
    {
        [BindProperty]
        public List<SubCategoryDTO> AllSubCategories { get; set; }
        [BindProperty]
        public List<int> SelectedSkillIds { get; set; }
        public List<int> CurrentExpertSkillsId { get; set; } 
        public async Task<IActionResult> OnGetAsync(int ExpertId,CancellationToken cancellationToken)
        {
            TempData["ExpertId"] = ExpertId;
            AllSubCategories = await categoryAppService.GetAllSubCategories(cancellationToken);
            if (AllSubCategories.IsNullOrEmpty())
            {
                return NotFound();
            }
            else
            {
                SelectedSkillIds = await categoryAppService.GetCategoryIdByExpertId(ExpertId,cancellationToken);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            int WantedExpertId = Convert.ToInt32(TempData["ExpertId"]);
            if (!ModelState.IsValid)
            {
                // دوباره لیست‌ها را لود کنید اگر خطا بود
                await OnGetAsync(WantedExpertId,cancellationToken);
                return Page();
            }

            // چک کردن اگر تغییری نبود، هیچ کاری نکن (اختیاری، اما طبق درخواست شما)
            var currentSkillIds = await categoryAppService.GetCategoryIdByExpertId(WantedExpertId, cancellationToken);
            var newSkillIds = SelectedSkillIds.OrderBy(id => id).ToList();
            if (!currentSkillIds.OrderBy(id => id).SequenceEqual(newSkillIds))
            {
                var Result= await expertAppService.UpdateExpertSkillsAsync(WantedExpertId, newSkillIds,cancellationToken);
                if (!Result)
                {
                    return BadRequest();
                }
            }
            return RedirectToPage("Index");

        }
    }
}