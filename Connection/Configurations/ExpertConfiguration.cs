using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Comments;
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

            builder.HasMany(x => x.Comments)
            .WithOne(x => x.Expert)
            .HasForeignKey(x => x.ExpertId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Expert>() {
                new Expert {Id = 1,TotalRate=0} });
        }
    }
}
