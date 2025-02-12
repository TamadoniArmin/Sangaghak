using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Users;

namespace App.Domain.Core.Sangaghak.Entities.Requests
{
    public class Suggest
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }
        public int AcceptedRequestId { get; set; }
        public Request AcceptedRequest { get; set; }
        public int SuggestedPrice { get; set; }
        public string Description { get; set; }
        public DateTime SuggestedTime { get; set; }
        public DateTime SetAt { get; set; }
    }
}
