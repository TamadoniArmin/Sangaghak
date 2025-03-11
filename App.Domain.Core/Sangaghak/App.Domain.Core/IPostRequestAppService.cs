using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using App.Domain.Core.Sangaghak.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IPostRequestAppService
    {
        public Task<bool> PostRequest(GetDataForCreateRequestDto requestDto, CancellationToken cancellationToken);
        public Task<List<ServicePackageDTO>> GetAllPackages(CancellationToken cancellationToken);
        public Task<UserBaseDTO> GetLogedInUser(int userId, CancellationToken cancellationToken);
    }
}
