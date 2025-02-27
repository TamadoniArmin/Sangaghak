using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Entities.Requests;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Sangaghak.Entities.Users
{
    public class Customer 
    {
        #region Properties
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
        #region NavigationProperties
        public List<Request>? Requets { get; set; }
        public List<Comment>? Comments { get; set; }
        #endregion
    }
}
