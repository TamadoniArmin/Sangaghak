using App.Domain.Core.Sangaghak.Enum;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Sangaghak.DTOs.Users
{
    public class UserForRegisterDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public RoleEnum Role { get; set; }
        public string Password { get; set; }
        public IFormFile? ProfileImgFile { get; set; }
        public string? ImagePath { get; set; }
    }
}
