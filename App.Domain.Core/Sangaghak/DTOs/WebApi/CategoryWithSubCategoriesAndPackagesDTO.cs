using App.Domain.Core.Sangaghak.DTOs.ServicePackages;
using System.Collections.Generic;

namespace App.Domain.Core.Sangaghak.DTOs.Categories
{
    public class CategoryWithSubCategoriesAndPackagesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public List<AllSubCategoryDTO> SubCategories { get; set; } = new List<AllSubCategoryDTO>();
    }

    public class AllSubCategoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int ParentId { get; set; }
        public List<AllServicePackageDTO> Packages { get; set; } = new List<AllServicePackageDTO>();
    }
}

namespace App.Domain.Core.Sangaghak.DTOs.ServicePackages
{
    public class AllServicePackageDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal MinPrice { get; set; }
        public string ImagePath { get; set; }
        public int SubCategoryId { get; set; }
    }
}