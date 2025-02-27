namespace App.Domain.Core.Sangaghak.DTOs.Categories
{
    public class SubCategoryFroCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int BasePrice { get; set; }
        public int ParentId { get; set; }
        public string ImagePath { get; set; }
    }
}
