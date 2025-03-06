using System.Net.Http.Headers;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.AspNetCore.Http;

namespace SangaghakService.Sangaghak.BaseEntities
{
    public class GeneralService : IGeneralService
    {
        public async Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellation)
        {
            string filePath;
            string fileName;
            if (FormFile != null)
            {
                fileName = Guid.NewGuid().ToString() +
                           ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
                filePath = Path.Combine($"wwwroot/images/{folderName}", fileName);
                try
                {
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await FormFile.CopyToAsync(stream, cancellation);
                    }
                }
                catch
                {
                    throw new Exception("Upload files operation failed");
                }
                return $"/images/{folderName}/{fileName}";//اینو بعدا درستش کن
            }
            else
                fileName = "";

            return fileName;
        }
    }
}
