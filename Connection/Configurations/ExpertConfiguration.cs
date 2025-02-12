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
            //builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Skills).WithMany(x => x.Experts);
        }
    }
}
