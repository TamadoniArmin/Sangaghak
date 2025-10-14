using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Entities.Users; 

namespace App.Domain.Core.Sangaghak.Entities.Users
{
    public class Customer
    {
        #region Properties
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
        #region NavigationProperties
        public List<Request>? Requests { get; set; }  
        public List<Comment>? Comments { get; set; }
        public UserBase? UserBase { get; set; }
        #endregion
    }
}