using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IExpertAppService
    {
        public Task<List<GetSubCategoryNameForExpertsDTO>?> GetExpertSkillsId(int ExpertId, CancellationToken cancellationToken);

    }
}
