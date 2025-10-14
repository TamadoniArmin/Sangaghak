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
            builder.HasData(new List<Customer>() {
                new Customer {Id = 1} });

            builder.HasOne(c => c.UserBase)
                .WithOne(u => u.Customer)
                .HasForeignKey<UserBase>(u => u.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}