using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SangaghakWebApiEndPoint.WebFramework.WebApi.Filters
{
    public class RequestActionFilter : ActionFilterAttribute
    {
        private const string ApiKeyHeaderName = "X-Api-Key";
        private readonly string _validApiKey;
        public RequestActionFilter(IConfiguration configuration)
        {
            _validApiKey = configuration["ApiKey"] ?? throw new ArgumentNullException(nameof(configuration), 
                "ApiKey is not configured in appsettings.json");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKey))
            {
                context.Result = new UnauthorizedObjectResult(new { message = "ApiKey header is missing." });
                return;
            }
            if (apiKey != _validApiKey)
            {
                context.Result = new UnauthorizedObjectResult(new { message = "Invalid ApiKey." });
                return;
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
