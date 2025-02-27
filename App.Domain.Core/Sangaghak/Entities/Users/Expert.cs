using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Entities.Requests;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Sangaghak.Entities.Users
{
    public class Expert 
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        #region Properties
        public List<int>? PointerIds { get; set; }
        public List<int>? Points { get; set; }
        public int TotalRate { get; set; }
        #endregion
        #region NavigationProperties
        public List<Category> Skills { get; set; }
        public List<Offer>? Offer { get; set; }
        public List<Comment>? Comments { get; set; }
        #endregion
    }
}
