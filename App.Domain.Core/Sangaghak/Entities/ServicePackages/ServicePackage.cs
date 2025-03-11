using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Entities.Requests;

namespace App.Domain.Core.Sangaghak.Entities.ServicePackages
{
    public class ServicePackage
    {
        #region Properties
        public int Id { get; set; }
        public string Tiltle { get; set; }
        public string Description { get; set; }
        public int MinPrice { get; set; }
        public string? ImagePath { get; set; }
        public int SubCategoryId { get; set; }
        public bool IsDeleted { get; set; } = false;
        #endregion
        #region NavigationProperties
        public Category? SubCategory { get; set; }
        public List<Request>? Requests { get; set; }
        #endregion

    }
}
