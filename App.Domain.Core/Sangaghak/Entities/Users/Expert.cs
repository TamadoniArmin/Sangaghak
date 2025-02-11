using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Entities.Requests;

namespace App.Domain.Core.Sangaghak.Entities.Users
{
    public class Expert : UserBase
    {
        public int Id { get; set; }
        public List<Category> Skills { get; set; }
        public List<Suggest> Suggests { get; set; }
        public List<Comment>? Comments { get; set; }
        public int TotalRate { get; set; }
    }
}
