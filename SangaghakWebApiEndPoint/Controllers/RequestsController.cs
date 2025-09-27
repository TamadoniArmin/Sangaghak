using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SangaghakWebApiEndPoint.WebFramework.ApiHelper;
using SangaghakWebApiEndPoint.WebFramework.WebApi.Filters;

namespace SangaghakWebApiEndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController(IRequestAppService requestAppService) : ControllerBase
    {
        [HttpGet("Get-All-Requests")]
        [ServiceFilter(typeof(RequestActionFilter))]
        public async Task<IActionResult> GetAllRequestsAsync(CancellationToken cancellationToken)
        {
            var allRequests= await requestAppService.GetAllRequestsAsync(cancellationToken);
            var result = new ApiResult<List<RequestDTO>,int,int>
            {
                IsSuccess = true,
                Massage = "درخواست ها با موفقیت از دیتا بیس خوانده شدند",
                Result1 = allRequests,
            };
            return Ok(result);
        }
    }
}
