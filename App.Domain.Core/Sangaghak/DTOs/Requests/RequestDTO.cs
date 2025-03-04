using App.Domain.Core.Sangaghak.Enum;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Sangaghak.DTOs.Requests
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int WantedPrice { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public string CityTitle { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerFullName { get; set; }
        public int ExpertId { get; set; }
        public string? ExpertFullName { get; set; }
        public string? ExpertEmail { get; set; }
        public string? ExpertPhone { get; set; }
        public int OfferPrice { get; set; }
        public DateTime? OfferDate { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryTitle { get; set; }
        public DateTime MaxTime { get; set; }
        public int? AcceptedOfferId { get; set; }
        public DateTime SetAt { get; set; }
        public RequestStatusEnum Status { get; set; }
        //public List<IFormFile>? Images { get; set; }
    }
}
