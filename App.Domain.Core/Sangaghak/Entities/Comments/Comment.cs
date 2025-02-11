using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;

namespace App.Domain.Core.Sangaghak.Entities.Comments
{
    public class Comment
    {
        #region Properties
        public int id { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public int CustomerId { get; set; }
        public int ExpertId { get; set; }
        public CommentStatusEnum Status { get; set; }
        #endregion


        #region NavigationProperties
        public Customer Customer { get; set; }
        public Expert Expert { get; set; }
        #endregion
    }
}
