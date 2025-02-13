using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Entities.Requests;

namespace App.Domain.Core.Sangaghak.Entities.Users
{
    public class Expert : UserBase
    {
        public List<Category> Skills { get; set; }
        public List<Offer>? Offer { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<int>? PointerIds { get; set; }
        public List<int>? Points { get; set; }
        public int TotalRate { get; set; }
    }
}
