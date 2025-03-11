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

            //builder.HasOne(x=>x.Customer)
            //    .WithMany(x=>x.Requets)
            //    .HasForeignKey(x=>x.CustomerId)
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.City)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AcceptedOffer)
                .WithOne(x => x.AcceptedRequest)
                .HasForeignKey<Request>(x => x.AcceptedOfferId)
                .OnDelete(DeleteBehavior.NoAction);


            //builder.HasData(new List<Request>
            //{ new Request {
            //Id = 1,
            //CustomerId = 1,
            //Description="درخواست برای کاغذ دیواری خانه",
            //WantedPrice=10000,
            //Address="خیابانی از خیابان های تهران",
            //MaxTime=DateTime.Parse("2025-12-01"),
            //Status=RequestStatusEnum.WatingForCustomerComfimation,
            //CityId=3,
            //ServicePackageId=1,
            //SetAt=DateTime.Parse("2024-09-01")
            //}
            //});
        }
    }
}
