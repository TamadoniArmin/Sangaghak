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
        [BindProperty]
        public int ExpertId { get; set; }
        [BindProperty]
        public int WantedExpertId { get; set; }



        public async Task<IActionResult> OnGet(int expertId, CancellationToken cancellationToken)
        {
            TempData["Armin"] = expertId;
            ExpertId = expertId; // ذخیره در پراپرتی
            AllSubCategories = await categoryAppService.GetAllSubCategories(cancellationToken);
            if (AllSubCategories.IsNullOrEmpty())
            {
                return NotFound();
            }
            else
            {
                SelectedSkillIds = await categoryAppService.GetCategoryIdByExpertId(ExpertId, cancellationToken);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateExpertSkills(CancellationToken cancellationToken)
        {
            int wantedExpertId = Convert.ToInt32(TempData["Armin"]);
            var currentSkillIds = await categoryAppService.GetCategoryIdByExpertId(WantedExpertId, cancellationToken);
            var newSkillIds = SelectedSkillIds.OrderBy(id => id).ToList();
            if (!currentSkillIds.OrderBy(id => id).SequenceEqual(newSkillIds))
            {
                var result = await expertAppService.UpdateExpertSkillsAsync(WantedExpertId, newSkillIds, cancellationToken);
                if (!result)
                {
                    return BadRequest();
                }
            }
            return RedirectToPage("Index");
        }
    }
}