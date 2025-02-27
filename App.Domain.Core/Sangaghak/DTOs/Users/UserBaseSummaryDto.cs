using App.Domain.Core.Sangaghak.Enum;

namespace App.Domain.Core.Sangaghak.DTOs.Users
{
    public class UserBaseSummaryDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string? Email { get; set; }
        public DateTime RegisterAt { get; set; }
        public string City { get; set; }
        public RoleEnum Role { get; set; }
        public string? ImagePath { get; set; }
    }
}
