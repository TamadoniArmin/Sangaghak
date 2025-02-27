using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Sangaghak.Service
{
    public interface IGeneralService
    {
        public Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellation);
    }
}
