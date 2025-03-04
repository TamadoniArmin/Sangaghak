using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Sangaghak.DTOs.Categories
{
    public class CategoryForCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
