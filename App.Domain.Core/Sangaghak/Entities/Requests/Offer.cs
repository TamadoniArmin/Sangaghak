using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Entities.Requests
{
    public class Offer
    {
        #region Properties
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public int RequestId { get; set; }
        public int OfferedPrice { get; set; }
        public string Description { get; set; }
        public DateTime OfferedTime { get; set; }
        public DateTime AcceptedAt { get; set; }
        public DateTime SetAt { get; set; }
        public bool IsDeleted { get; set; }=false;
        #endregion
        #region NavigationProperties
        public Expert Expert { get; set; }
        public Request Request { get; set; }
        public Request? AcceptedRequest { get; set; }
        #endregion
    }
}
