using App.Domain.Core.Sangaghak.DTOs.Categories;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.Users;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IExpertAppService
    {
        public Task<bool> CheckExpertHasAnySkillAsync(int ExpertId, CancellationToken cancellationToken);
        public Task<GetUserBaseForViewPage> UserSummary(int UserId, CancellationToken cancellationToken);
        public Task<bool> UpdateExpertSkillsAsync(int expertId, List<int> newSkillIds,CancellationToken cancellationToken);
        public Task<List<RequestDTO>?> GetMathRequestForExpertInfo(int ExpertId, int CityId, CancellationToken cancellationToken);
    }
}
