using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Entities.Requests;

namespace App.Domain.Core.Sangaghak.Entities.Users
{
    public class Customer : UserBase
    {
        public int Id { get; set; }
        public List<Request>? Requets { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
