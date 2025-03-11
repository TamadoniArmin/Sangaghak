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
        public int ServicePackageId { get; set; }
        public DateTime MaxTime { get; set; }
        public string? ImagePath1 { get; set; }
        public string? ImagePath2 { get; set; }
        public IFormFile? ImageFile1 { get; set; }
        public IFormFile? ImageFile2 { get; set; }
    }
}
