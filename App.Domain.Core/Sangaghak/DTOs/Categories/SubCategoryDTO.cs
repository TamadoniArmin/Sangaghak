using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Sangaghak.DTOs.Categories
{
    public class SubCategoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public string? ParentName { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
