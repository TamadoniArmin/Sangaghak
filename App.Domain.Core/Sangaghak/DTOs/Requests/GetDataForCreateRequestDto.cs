using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Sangaghak.DTOs.Requests
{
    public class GetDataForCreateRequestDto
    {
        public string Description { get; set; }
        public int WantedPrice { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int CustomerId { get; set; }
        public int CategoryId { get; set; }
        public DateTime MaxTime { get; set; }
    }
}
