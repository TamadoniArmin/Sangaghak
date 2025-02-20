using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Sangaghak.Entities.Users
{
    public class UserBase : IdentityUser<int>
    {
        #region properties  
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public DateTime RegisteredAt { get; set; }
        public int Balance { get; set; } = 0;
        public int CityId { get; set; }
        public int RoleId { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region NavigationProperties
        public Image? Image { get; set; }
        public Role Role { get; set; }
        public City City { get; set; }
        #endregion
    }
}
