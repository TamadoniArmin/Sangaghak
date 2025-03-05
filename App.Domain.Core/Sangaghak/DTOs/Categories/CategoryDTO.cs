using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Sangaghak.DTOs.Categories
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IFormFile? ImgFile { get; set; }
        public int SubCategoryCount { get; set; }
    }
}
