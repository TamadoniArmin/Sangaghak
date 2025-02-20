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
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //builder.HasData(new List<Customer>() {
            //    new Customer {Id = 2,
            //        Email="Mehdi@Mehdi.com",
            //        Phone="0912345678",
            //        Password="123456",
            //        FirstName="Mehdi",
            //        LastName="Mortazavi",
            //        UserName="mehdi",
            //        RoleId=2,
            //        Balance=10000,
            //        CityId=2,
            //        RegisteredAt=new DateTime(2025,1,1,0,0,0)
            //    } });
        }
    }
}
