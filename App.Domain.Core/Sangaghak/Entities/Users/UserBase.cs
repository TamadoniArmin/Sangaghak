using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using App.Domain.Core.Sangaghak.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Sangaghak.Entities.Users
{
    public class UserBase : IdentityUser<int>
    {
        #region properties  
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Mobile { get; set; }
        public DateTime RegisteredAt { get; set; }
        public int Balance { get; set; } = 0;
        public int CityId { get; set; }
        public int RoleId { get; set; }
        public bool IsDeleted { get; set; }
        public string? ImagePath { get; set; }
        public int? AdminId { get; set; }
        public int? ExpertId { get; set; }
        public int? CustomerId { get; set; }

        #endregion

        #region NavigationProperties
        public RoleEnum Role { get; set; }
        public City City { get; set; }
        public Admin? Admin { get; set; }
        public Customer? Customer { get; set; }
        public Expert? Expert { get; set; }
        #endregion
    }
}
