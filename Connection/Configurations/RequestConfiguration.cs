using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.Customer)
                .WithMany(x=>x.Requets)
                .HasForeignKey(x=>x.CustomerId);

            builder.HasOne(x => x.City)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x=>x.AcceptedOffer)
                .WithOne(x => x.AcceptedRequest)
                .HasForeignKey<Request>(x=>x.AcceptedOfferId)
                .OnDelete(DeleteBehavior.NoAction);


            //builder.HasData(new List<Request>
            //{ new Request {
            //Id = 1,
            //CustomerId = 2,
            //Title="درخواست برای کاغذ دیواری خانه",
            //WantedPrice=10000,
            //WantedTime=new DateTime (2025,12,12,10,12,0),
            //Status=RequestStatusEnum.WatingForExpertsOffers,
            //CityId=3,
            //CategoryId=9,
            //SetAt=new DateTime(2025,1,1,0,0,0)
            //}
            //});
        }
    }
}
