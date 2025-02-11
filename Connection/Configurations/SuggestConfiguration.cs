using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configurations
{
    public class SuggestConfiguration : IEntityTypeConfiguration<Suggest>
    {
        public void Configure(EntityTypeBuilder<Suggest> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Expert)
                .WithMany(x => x.Suggests)
                .HasForeignKey(x => x.ExpertId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Request)
                .WithMany(x => x.Suggests)
                .HasForeignKey(x => x.RequestId);

            builder.HasOne(x=>x.AcceptedRequest)
                .WithOne(x => x.AcceptedSugget)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
