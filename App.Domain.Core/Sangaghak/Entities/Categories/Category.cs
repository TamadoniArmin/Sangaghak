using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Entities.Users;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Sangaghak.Entities.Categories
{
    public class Category
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BasePrice { get; set; }
        public int? ParentId { get; set; }
        public string? ImagePath { get; set; }
        public bool IsDeleted { get; set; } = false;
        #endregion


        #region NavigationProperties
        public List<Category>? Subcategories { get; set; }
        public Category? ParentCategory { get; set; }
        public List<Request>? Requests { get; set; }
        public List<Expert>? Experts { get; set; }
        #endregion
    }
}
