using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Entities.BaseEntities
{
    public class City
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<UserBase> Users { get; set; }
        public List<Request> Requests { get; set; }
    }
}
