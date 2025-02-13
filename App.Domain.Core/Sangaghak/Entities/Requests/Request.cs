using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using App.Domain.Core.Sangaghak.Entities.Categories;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;

namespace App.Domain.Core.Sangaghak.Entities.Requests
{
    public class Request
    {
        #region Properties
        public int RequestId { get; set; }
        public string Title { get; set; }
        public int WantedPrice { get; set; }
        public DateTime WantedTime { get; set; }
        public RequestStatusEnum Status { get; set; }
        public int CityId { get; set; }
        public int CustomerId { get; set; }
        public int CategoryId { get; set; }
        public DateTime SetAt { get; set; }

        #endregion

        #region NavigationProperties
        public List<Offer>? Offers { get; set; }
        public Category Category { get; set; }
        public Customer Customer { get; set; }
        public Offer? AcceptedOffer { get; set; }
        public List<Image>? Images { get; set; }
        public City City { get; set; }
        #endregion

    }
}
