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
    public class UserBaseConfiguration : IEntityTypeConfiguration<UserBase>
    {
        public void Configure(EntityTypeBuilder<UserBase> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.City)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasData(new List<UserBase>() {
            //    new UserBase {Id = 1,
            //        Email="Admin@Admin.com",
            //        Phone="09130609857",
            //        Password="123456",
            //        FirstName="Armin",
            //        LastName="Tamadoni",
            //        UserName="Admin",
            //        RoleId=1,
            //        Balance=10000,
            //        CityId=3,
            //        RegisteredAt=new DateTime(2025,1,1,0,0,0)
            //    } });
        }
    }
}
