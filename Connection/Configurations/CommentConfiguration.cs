using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x=>x.id);

            builder.HasOne(x=>x.Customer)
                .WithMany(x=>x.Comments)
                .HasForeignKey(x=>x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Expert)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.ExpertId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
