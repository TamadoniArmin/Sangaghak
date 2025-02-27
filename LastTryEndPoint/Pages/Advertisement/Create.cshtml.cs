using Divarcheh.Domain.Core.Contracts.AppService;
using Divarcheh.Domain.Core.Dto.Advertisement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Divarcheh.Endpoints.RazorPages.Pages.Advertisement
{
    public class CreateModel : PageModel
    {
        private readonly IAdvertisementAppService _advertisementAppService;

        [BindProperty]
        public GetForItemsOutputDto FormItems { get; set; }
        public CreateModel(IAdvertisementAppService advertisementAppService)
        {
            _advertisementAppService = advertisementAppService;
        }

        public async Task OnGet(int childCategoryId , CancellationToken cancellationToken)
        {
            FormItems = await _advertisementAppService.GetForItems(childCategoryId, cancellationToken);
        }
    }
}
