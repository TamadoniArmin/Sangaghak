using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Entities.BaseEntities
{
    public class Image
    {
        #region Properties
        public int Id { get; set; }
        public string Path { get; set; }
        public int UserId { get; set; }
        public int RequestId { get; set; }
        public int CategoryId { get; set; }
        #endregion
        #region NavigationProperties
        //public UserBase? User { get; set; }
        public Request? Request { get; set; }
        //public Category? Category { get; set; }
        #endregion
    }
}
