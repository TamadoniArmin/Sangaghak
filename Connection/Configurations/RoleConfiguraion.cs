using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configurations
{
    public class RoleConfiguraion : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.HasData(new List<Role>()
            //{
            //    new Role() {Id = 1 ,Title = "Admin"},
            //    new Role() {Id = 2 ,Title = "Customer"},
            //    new Role() {Id = 3 ,Title = "Expert"},
            //});
        }
    }
}
