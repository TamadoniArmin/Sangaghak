using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Entities.Categories
{
    public class Category
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        //public int ImegeId { get; set; }
        #endregion


        #region NavigationProperties
        public Image Image { get; set; }
        public List<Category>? Subcategories { get; set; }
        public Category? ParentCategory { get; set; }
        public List<Request> Requests { get; set; }
        public List<Expert> Experts { get; set; }
        #endregion
    }
}
