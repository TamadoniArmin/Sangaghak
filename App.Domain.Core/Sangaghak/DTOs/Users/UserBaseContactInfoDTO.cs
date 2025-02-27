using App.Domain.Core.Sangaghak.Entities.BaseEntities;

namespace App.Domain.Core.Sangaghak.DTOs.Users
{
    public class UserBaseContactInfoDTO
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
    }
}
