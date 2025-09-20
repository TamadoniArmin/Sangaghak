namespace App.Domain.Core.Sangaghak.DTOs.Users
{
    public class UserBasicInfoDTO
    {
        public int Id { get; set; }
        public string UserName  { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public int ExpertId { get; set; }
        public int CustomerId { get; set; }
        public int AdminId { get; set; }
    }
}
