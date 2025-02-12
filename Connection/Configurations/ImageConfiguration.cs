using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithOne(x=>x.Image)
                .HasForeignKey<Image>(x=>x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x=>x.Request)
                .WithMany(x=>x.Images)
                .HasForeignKey(x=>x.RequestId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x=>x.Category)
                .WithOne(x=>x.Image)
                .HasForeignKey<Image>(x=>x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
