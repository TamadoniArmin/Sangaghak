using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
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
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Expert)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Request)
                .WithOne(x => x.Comment)
                .HasForeignKey<Comment>(x => x.RequestId)
                .OnDelete(DeleteBehavior.NoAction);


            //builder.HasData(new List<Comment>()
            //{
            //    new Comment
            //    {
            //        id = 1,
            //        Description="بسیار عالی و وقت شناس",
            //        Rate=4,
            //        CustomerId=1,
            //        ExpertId=1,
            //        RequestId=1,
            //    }
            //});
        }
    }
}
