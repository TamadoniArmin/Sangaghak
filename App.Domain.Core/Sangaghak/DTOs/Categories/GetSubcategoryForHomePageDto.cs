namespace App.Domain.Core.Sangaghak.DTOs.Categories
{
    public class GetSubcategoryForHomePageDto
    {
        public int CategoryId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BasePrice { get; set; }
        public string? ImagePath { get; set; }
        public int RequestsCount { get; set; }
        public int ExpertsCount { get; set; }
    }
}
