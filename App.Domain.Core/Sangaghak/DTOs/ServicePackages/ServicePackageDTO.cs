using System.Security.Principal;

namespace App.Domain.Core.Sangaghak.DTOs.ServicePackages
{
    public class ServicePackageDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MinPrice { get; set; }
        public int SubCategoryId { get; set; }
        public string? SubCategoryTiltle { get; set; }
        public string? ImagePath { get; set; }
    }
}
