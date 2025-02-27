namespace App.Domain.Core.Sangaghak.DTOs.Categories
{
    public class GetCategoryForHomePageDto
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public int SubCategoryCount { get; set; }
    }
}
