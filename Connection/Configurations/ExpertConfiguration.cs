using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configurations
{
    public class ExpertConfiguration : IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> builder)
        {
            builder.HasMany(x => x.Skills).WithMany(x => x.Experts);
            builder.HasData(new List<Expert>() {
                new Expert {Id = 3,
                    Email="Hassan@Hassan.com",
                    Phone="09987654321",
                    Password="123456",
                    FirstName="Hassan",
                    LastName="Hassani",
                    UserName="hassan",
                    RoleId=3,
                    TotalRate=0,
                    Balance=10000,
                    CityId=5,
                    RegisteredAt=new DateTime(2025,1,1,0,0,0)
                } });
        }
    }
}
